using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(ProjectMaterialRequestRow))]
    public class ProjectMaterialRequestController : Controller
    {
        [Route("Projects/ProjectMaterialRequest")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/ProjectMaterialRequest/ProjectMaterialRequestIndex.cshtml");
        }
    }
}