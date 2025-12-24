using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(TransferOrderDetailRow))]
    public class TransferOrderDetailController : Controller
    {
        [Route("Inventory/TransferOrderDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/TransferOrderDetail/TransferOrderDetailIndex.cshtml");
        }
    }
}