using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Merchandise.Pages
{

    [PageAuthorize(typeof(SACRow))]
    public class SACController : Controller
    {
        [Route("Merchandise/SAC")]
        public ActionResult Index()
        {
            return View("~/Modules/Merchandise/SAC/SACIndex.cshtml");
        }
    }
}