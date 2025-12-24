using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(vwProjectFundRow))]
    public class VwProjectFundController : Controller
    {
        [Route("Projects/VwProjectFund")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/VwProjectFund/VwProjectFundIndex.cshtml");
        }
    }
}