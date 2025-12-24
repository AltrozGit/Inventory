using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(ShipperRow))]
    public class ShipperController : Controller
    {
        [Route("Inventory/Shipper")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/Shipper/ShipperIndex.cshtml");
        }
    }
}