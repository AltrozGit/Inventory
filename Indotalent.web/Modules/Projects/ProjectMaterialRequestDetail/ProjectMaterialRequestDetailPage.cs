using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(ProjectMaterialRequestDetailRow))]
    public class ProjectMaterialRequestDetailController : Controller
    {
        [Route("Projects/ProjectMaterialRequestDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/ProjectMaterialRequestDetail/ProjectMaterialRequestDetailIndex.cshtml");
        }
    }
}