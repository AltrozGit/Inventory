using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(ProjectFundRow))]
    public class ProjectFundController : Controller
    {
        [Route("Projects/ProjectFund")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/ProjectFund/ProjectFundIndex.cshtml");
        }
    }
}