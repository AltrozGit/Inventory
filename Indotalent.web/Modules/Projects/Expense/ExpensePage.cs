using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(ExpenseRow))]
    public class ExpenseController : Controller
    {
        [Route("Projects/Expense")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/Expense/ExpenseIndex.cshtml");
        }
    }
}