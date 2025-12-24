using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(TransferOrderRow))]
    public class TransferOrderController : Controller
    {
        [Route("Inventory/TransferOrder")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/TransferOrder/TransferOrderIndex.cshtml");
        }
    }
}