using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(WhatsAppRow))]
    public class WhatsAppController : Controller
    {
        [Route("Reminder/WhatsApp")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/WhatsApp/WhatsAppIndex.cshtml");
        }
    }
}