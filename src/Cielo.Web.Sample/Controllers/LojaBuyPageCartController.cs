using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Requests;
using Cielo.Requests.Entities;
using Cielo.Responses;
using Cielo.Responses.Exceptions;

namespace Cielo.Web.Sample.Controllers
{
    public class LojaBuyPageCartController : Controller
    {
        private CieloService _cieloService;
        private string _randomOrderId;
        private CustomCieloConfiguration _configuration;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _cieloService = new CieloService();
            _randomOrderId = new Random().Next(11111, 9999999).ToString(CultureInfo.InvariantCulture);
            _configuration = new CustomCieloConfiguration
            {
                CurrencyId = "986",
                CustomerId = "1006993069",
                CustomerKey = "25fbb99741c739dd84d7b06ec78c9bac718838630f30b112d033ce2e621b34f3",
                Language = Language.Portuguese,
                ReturnUrl = "http://localhost:5654/LojaBuyPageCart/Callback"
            };

            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel creditCardValues)
        {
            var yearExpiration = Convert.ToInt16((string)creditCardValues.ExpirationYear);
            var monthExpiration = Convert.ToByte((string)creditCardValues.ExpirationMonth);

            var order = new Order(_randomOrderId, 4700.00m, DateTime.Now, "Goku e GokuSSJ");
            var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.Credit);
            var options = new CreateTransactionOptions(AuthorizationType.AuthorizeSkippingAuthentication, capture: true);
            var creditCardData = new CreditCardData(creditCardValues.CreditCardNumber, new CreditCardExpiration(yearExpiration, monthExpiration), SecurityCodeIndicator.Sent, creditCardValues.SecurityCode);
            var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, options, creditCardData, _configuration);

            try
            {
                var response = _cieloService.CreateTransaction(createTransactionRequest);
                Session["tid"] = response.Tid;
                return Redirect("CheckStatus");
            }
            catch (ResponseException ex)
            {
                ViewBag.MessageError = ex.Message;
                return View(creditCardValues);
            }
        }

        public ActionResult CheckStatus()
        {
            var checkTransactionRequest = new CheckTransactionRequest((string)Session["tid"], _configuration);
            CheckTransactionResponse response = _cieloService.CheckTransaction(checkTransactionRequest);
            ViewBag.Status = response.Status.ToString();

            return View();
        }

        public ActionResult CancelOrder()
        {
            var cancelTransactionRequest = new CancelTransactionRequest((string)Session["tid"], _configuration);
            CancelTransactionResponse response = _cieloService.CancelTransaction(cancelTransactionRequest);
            ViewBag.Status = response.Status.ToString();

            return RedirectToAction("CheckStatus");
        }

        public class CheckoutViewModel
        {
            public string SecurityCode { get; set; }
            public string ExpirationYear { get; set; }
            public string ExpirationMonth { get; set; }
            public string CreditCardNumber { get; set; }
        }
    }
}