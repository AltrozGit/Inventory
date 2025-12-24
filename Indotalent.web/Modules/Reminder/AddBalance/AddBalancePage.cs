using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(AddBalanceRow))]
    public class AddBalanceController : Controller
    {
        [Route("Reminder/AddBalance")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/AddBalance/AddBalanceIndex.cshtml");
        }
    }
}