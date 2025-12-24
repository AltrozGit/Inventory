using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(SubscriptionRow))]
    public class SubscriptionController : Controller
    {
        [Route("Reminder/Subscription")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/Subscription/SubscriptionIndex.cshtml");
        }
    }
}