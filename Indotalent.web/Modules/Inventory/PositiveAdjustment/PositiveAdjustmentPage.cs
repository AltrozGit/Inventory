using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(PositiveAdjustmentRow))]
    public class PositiveAdjustmentController : Controller
    {
        [Route("Inventory/PositiveAdjustment")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/PositiveAdjustment/PositiveAdjustmentIndex.cshtml");
        }
    }
}