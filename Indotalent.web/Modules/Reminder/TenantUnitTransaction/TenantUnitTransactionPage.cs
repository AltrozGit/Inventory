using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(TenantUnitTransactionRow))]
    public class TenantUnitTransactionController : Controller
    {
        [Route("Reminder/TenantUnitTransaction")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/TenantUnitTransaction/TenantUnitTransactionIndex.cshtml");
        }
    }
}