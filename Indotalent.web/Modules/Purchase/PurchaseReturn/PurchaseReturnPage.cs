using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Purchase.Pages
{

    [PageAuthorize(typeof(PurchaseReturnRow))]
    public class PurchaseReturnController : Controller
    {
        [Route("Purchase/PurchaseReturn")]
        public ActionResult Index()
        {
            return View("~/Modules/Purchase/PurchaseReturn/PurchaseReturnIndex.cshtml");
        }
    }
}