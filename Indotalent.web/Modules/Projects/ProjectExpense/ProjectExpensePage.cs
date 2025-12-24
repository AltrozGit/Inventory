using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(ProjectExpenseRow))]
    public class ProjectExpenseController : Controller
    {
        [Route("Projects/ProjectExpense")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/ProjectExpense/ProjectExpenseIndex.cshtml");
        }
    }
}