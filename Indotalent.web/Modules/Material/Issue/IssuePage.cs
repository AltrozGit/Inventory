using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(IssueRow))]
    public class IssueController : Controller
    {
        [Route("Material/Issue")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/Issue/IssueIndex.cshtml");
        }
    }
}