using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(WarehouseRow))]
    public class WarehouseController : Controller
    {
        [Route("Inventory/Warehouse")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/Warehouse/WarehouseIndex.cshtml");
        }
    }
}