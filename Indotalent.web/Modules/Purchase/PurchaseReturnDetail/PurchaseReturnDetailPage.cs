using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Purchase.Pages
{

    [PageAuthorize(typeof(PurchaseReturnDetailRow))]
    public class PurchaseReturnDetailController : Controller
    {
        [Route("Purchase/PurchaseReturnDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Purchase/PurchaseReturnDetail/PurchaseReturnDetailIndex.cshtml");
        }
    }
}