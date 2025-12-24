using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Purchase.Pages
{

    [PageAuthorize(typeof(PurchaseReceiptDetailRow))]
    public class PurchaseReceiptDetailController : Controller
    {
        [Route("Purchase/PurchaseReceiptDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Purchase/PurchaseReceiptDetail/PurchaseReceiptDetailIndex.cshtml");
        }
    }
}