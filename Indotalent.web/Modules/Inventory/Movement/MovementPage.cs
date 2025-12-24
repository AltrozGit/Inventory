using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Inventory.Pages
{

    [PageAuthorize(typeof(MovementRow))]
    public class MovementController : Controller
    {
        [Route("Inventory/Movement")]
        public ActionResult Index()
        {
            return View("~/Modules/Inventory/Movement/MovementIndex.cshtml");
        }
    }
}