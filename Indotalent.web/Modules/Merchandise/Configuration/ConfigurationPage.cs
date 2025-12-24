using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Merchandise.Pages
{

    [PageAuthorize(typeof(ConfigurationRow))]
    public class ConfigurationController : Controller
    {
        [Route("Merchandise/Configuration")]
        public ActionResult Index()
        {
            return View("~/Modules/Merchandise/Configuration/ConfigurationIndex.cshtml");
        }
    }
}