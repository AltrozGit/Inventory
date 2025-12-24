using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(BulkEmailSenderStatusRow))]
    public class BulkEmailSenderStatusController : Controller
    {
        [Route("Reminder/BulkEmailSenderStatus")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/BulkEmailSenderStatus/BulkEmailSenderStatusIndex.cshtml");
        }
    }
}