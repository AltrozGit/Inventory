using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(DueDateReminderRow))]
    public class DueDateReminderController : Controller
    {
        [Route("Reminder/DueDateReminder")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/DueDateReminder/DueDateReminderIndex.cshtml");
        }
    }
}