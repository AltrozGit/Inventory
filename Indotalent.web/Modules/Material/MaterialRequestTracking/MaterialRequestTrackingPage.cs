using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(MaterialRequestTrackingRow))]
    public class MaterialRequestTrackingController : Controller
    {
        [Route("Material/MaterialRequestTracking")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/MaterialRequestTracking/MaterialRequestTrackingIndex.cshtml");
        }
    }
}