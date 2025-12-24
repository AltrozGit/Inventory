using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.WhatsApp.Pages
{

    [PageAuthorize(typeof(WhatsAppTemplateRow))]
    public class WhatsAppTemplateController : Controller
    {
        [Route("WhatsApp/WhatsAppTemplate")]
        public ActionResult Index()
        {
            return View("~/Modules/WhatsApp/WhatsAppTemplate/WhatsAppTemplateIndex.cshtml");
        }
    }
}