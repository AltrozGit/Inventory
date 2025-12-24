using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(IssueDetailRow))]
    public class IssueDetailController : Controller
    {
        [Route("Material/IssueDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/IssueDetail/IssueDetailIndex.cshtml");
        }
    }
}