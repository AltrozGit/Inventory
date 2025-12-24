using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Merchandise.Pages
{

    [PageAuthorize(typeof(HSNRow))]
    public class HSNController : Controller
    {
        [Route("Merchandise/HSN")]
        public ActionResult Index()
        {
            return View("~/Modules/Merchandise/HSN/HSNIndex.cshtml");
        }
    }
}