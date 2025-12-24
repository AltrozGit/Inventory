using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(SmtpConfigurationRow))]
    public class SmtpConfigurationController : Controller
    {
        [Route("Reminder/SmtpConfiguration")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/SmtpConfiguration/SmtpConfigurationIndex.cshtml");
        }
    }
}