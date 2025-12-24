using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Bills.Pages
{

    [PageAuthorize(typeof(BillRow))]
    public class BillController : Controller
    {
        [Route("Bills/Bill")]
        public ActionResult Index()
        {
            return View("~/Modules/Bills/Bill/BillIndex.cshtml");
        }
    }
}