using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(PositiveAdjustmentDetailRow))]
    public class PositiveAdjustmentDetailController : Controller
    {
        [Route("Inventory/PositiveAdjustmentDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/PositiveAdjustmentDetail/PositiveAdjustmentDetailIndex.cshtml");
        }
    }
}