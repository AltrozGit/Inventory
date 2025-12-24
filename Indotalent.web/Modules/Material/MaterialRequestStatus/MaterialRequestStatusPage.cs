using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(MaterialRequestStatusRow))]
    public class MaterialRequestStatusController : Controller
    {
        [Route("Material/MaterialRequestStatus")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/MaterialRequestStatus/MaterialRequestStatusIndex.cshtml");
        }
    }
}