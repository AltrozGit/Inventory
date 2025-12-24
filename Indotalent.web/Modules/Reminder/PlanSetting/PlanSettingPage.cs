using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(PlanSettingRow))]
    public class PlanSettingController : Controller
    {
        [Route("Reminder/PlanSetting")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/PlanSetting/PlanSettingIndex.cshtml");
        }
    }
}