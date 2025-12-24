using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.General.Pages
{

    [PageAuthorize(typeof(ActionRow))]
    public class ActionController : Controller
    {
        [Route("General/Action")]
        public ActionResult Index()
        {
            return View("~/Modules/General/Action/ActionIndex.cshtml");
        }
    }
}