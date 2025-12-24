using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(RequestDetailRow))]
    public class RequestDetailController : Controller
    {
        [Route("Material/RequestDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/RequestDetail/RequestDetailIndex.cshtml");
        }
    }
}