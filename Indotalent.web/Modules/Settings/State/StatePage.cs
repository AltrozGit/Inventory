using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Settings.Pages
{

    [PageAuthorize(typeof(StateRow))]
    public class StateController : Controller
    {
        [Route("Settings/State")]
        public ActionResult Index()
        {
            return View("~/Modules/Settings/State/StateIndex.cshtml");
        }
    }
}