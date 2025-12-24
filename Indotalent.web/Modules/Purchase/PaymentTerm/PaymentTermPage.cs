using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Purchase.Pages
{

    [PageAuthorize(typeof(PaymentTermRow))]
    public class PaymentTermController : Controller
    {
        [Route("Purchase/PaymentTerm")]
        public ActionResult Index()
        {
            return View("~/Modules/Purchase/PaymentTerm/PaymentTermIndex.cshtml");
        }
    }
}