using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.General.Pages
{

    [PageAuthorize(typeof(TemplateRow))]
    public class TemplateController : Controller
    {
        [Route("General/Template")]
        public ActionResult Index()
        {
            return View("~/Modules/General/Template/TemplateIndex.cshtml");
        }
    }
}