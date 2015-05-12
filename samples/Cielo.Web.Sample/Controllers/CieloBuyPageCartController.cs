using System;
using System.Globalization;
using System.Web.Mvc;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Requests;
using Cielo.Requests.Entities;
using Cielo.Responses;

namespace Cielo.Web.Sample.Controllers
{
    public class CieloBuyPageCartController : Controller
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
                CustomerId = "1001734898",
                CustomerKey = "e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832",
                Language = Language.Portuguese,
                ReturnUrl = "http://localhost:5654/CieloBuyPageCart/Callback"
            };

            base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout()
        {
            var order = new Order(_randomOrderId, 4700.00m, DateTime.Now, "Goku e GokuSSJ");

            //Crédito - A vista
            var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.Credit);
            var options = new CreateTransactionOptions(AuthorizationType.AuthorizeSkippingAuthentication, capture: true);

            //Crédito - Parcelado Loja
            //var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.StoreInstallmentPayment, 5);
            //var options = new CreateTransactionOptions(AuthorizationType.AuthorizeSkippingAuthentication, capture: true);

            //Débito
            //var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.Debit);
            //var options = new CreateTransactionOptions(AuthorizationType.AuthorizeAuthenticatedOrNot, capture: true);
            var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, options, configuration: _configuration);
            CreateTransactionResponse response = _cieloService.CreateTransaction(createTransactionRequest);

            Session["tid"] = response.Tid;
            return Redirect(response.AuthenticationUrl);
        }

        public ActionResult Callback()
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

            return RedirectToAction("Callback");
        }
    }
}
