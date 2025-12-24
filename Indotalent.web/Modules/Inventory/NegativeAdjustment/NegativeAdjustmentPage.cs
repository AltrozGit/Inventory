using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(NegativeAdjustmentRow))]
    public class NegativeAdjustmentController : Controller
    {
        [Route("Inventory/NegativeAdjustment")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/NegativeAdjustment/NegativeAdjustmentIndex.cshtml");
        }
    }
}