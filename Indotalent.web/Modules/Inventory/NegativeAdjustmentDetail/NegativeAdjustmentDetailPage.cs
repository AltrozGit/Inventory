using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(NegativeAdjustmentDetailRow))]
    public class NegativeAdjustmentDetailController : Controller
    {
        [Route("Inventory/NegativeAdjustmentDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/NegativeAdjustmentDetail/NegativeAdjustmentDetailIndex.cshtml");
        }
    }
}