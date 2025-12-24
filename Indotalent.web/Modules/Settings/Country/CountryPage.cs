using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Settings.Pages
{

    [PageAuthorize(typeof(CountryRow))]
    public class CountryController : Controller
    {
        [Route("Settings/Country")]
        public ActionResult Index()
        {
            return View("~/Modules/Settings/Country/CountryIndex.cshtml");
        }
    }
}