using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(QuotationRow))]
    public class QuotationController : Controller
    {
        [Route("Projects/Quotation")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/Quotation/QuotationIndex.cshtml");
        }
    }
}