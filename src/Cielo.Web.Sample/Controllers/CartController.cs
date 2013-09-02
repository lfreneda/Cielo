using System;
using System.Globalization;
using System.Web.Mvc;
using Cielo.Enums;
using Cielo.Requests;
using Cielo.Requests.Entities;
using Cielo.Responses;

namespace Cielo.Web.Sample.Controllers
{
    public class CartController : Controller
    {
        private CieloService _cieloService;
        private string _randomOrderId;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _cieloService = new CieloService();
            _randomOrderId = new Random().Next(11111, 9999999).ToString(CultureInfo.InvariantCulture);
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
            var paymentMethod = new PaymentMethod(CreditCard.MasterCard, PurchaseType.Credit);
            var options = new CreateTransactionOptions(AuthorizationType.AuthorizePassByAuthentication, capture: true);
            var createTransactionRequest = new CreateTransactionRequest(order, paymentMethod, options);
            CreateTransactionResponse response = _cieloService.CreateTransaction(createTransactionRequest);

            Session["tid"] = response.Tid;
            return Redirect(response.AuthenticationUrl);
        }

        public ActionResult Callback()
        {
            var checkTransactionRequest = new CheckTransactionRequest((string)Session["tid"]);
            CheckTransactionResponse response = _cieloService.CheckTransaction(checkTransactionRequest);
            ViewBag.Status = response.Status.ToString();

            return View();
        }
    }
}
