using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(PlanRow))]
    public class PlanController : Controller
    {
        [Route("Reminder/Plan")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/Plan/PlanIndex.cshtml");
        }
    }
}