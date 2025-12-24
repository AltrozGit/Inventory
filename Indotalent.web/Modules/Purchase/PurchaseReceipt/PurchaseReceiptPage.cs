using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Purchase.Pages
{

    [PageAuthorize(typeof(PurchaseReceiptRow))]
    public class PurchaseReceiptController : Controller
    {
        [Route("Purchase/PurchaseReceipt")]
        public ActionResult Index()
        {
            return View("~/Modules/Purchase/PurchaseReceipt/PurchaseReceiptIndex.cshtml");
        }
    }
}