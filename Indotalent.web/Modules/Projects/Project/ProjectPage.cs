using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(ProjectRow))]
    public class ProjectController : Controller
    {
        [Route("Projects")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/Project/ProjectIndex.cshtml");
        }
    }
}