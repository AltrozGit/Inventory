using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(LocationRow))]
    public class LocationController : Controller
    {
        [Route("Inventory/Location")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/Location/LocationIndex.cshtml");
        }
    }
}