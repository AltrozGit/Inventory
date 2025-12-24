using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(RequestRow))]
    public class RequestController : Controller
    {
        [Route("Material/Request")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/Request/RequestIndex.cshtml");
        }
    }
}