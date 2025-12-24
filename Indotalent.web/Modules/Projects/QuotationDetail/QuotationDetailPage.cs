using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Projects.Pages
{

    [PageAuthorize(typeof(QuotationDetailRow))]
    public class QuotationDetailController : Controller
    {
        [Route("Projects/QuotationDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Projects/QuotationDetail/QuotationDetailIndex.cshtml");
        }
    }
}