using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(StockRow))]
    public class StockController : Controller
    {
        [Route("Inventory/Stock")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/Stock/StockIndex.cshtml");
        }
    }
}