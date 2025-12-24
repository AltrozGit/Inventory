using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(StatusMasterRow))]
    public class StatusMasterController : Controller
    {
        [Route("Material/StatusMaster")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/StatusMaster/StatusMasterIndex.cshtml");
        }
    }
}