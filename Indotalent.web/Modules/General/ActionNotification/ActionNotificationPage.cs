using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.General.Pages
{

    [PageAuthorize(typeof(ActionNotificationRow))]
    public class ActionNotificationController : Controller
    {
        [Route("General/ActionNotification")]
        public ActionResult Index()
        {
            return View("~/Modules/General/ActionNotification/ActionNotificationIndex.cshtml");
        }
    }
}