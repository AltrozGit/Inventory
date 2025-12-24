using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Bills.Pages
{

    [PageAuthorize(typeof(BillDetailRow))]
    public class BillDetailController : Controller
    {
        [Route("Bills/BillDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Bills/BillDetail/BillDetailIndex.cshtml");
        }
    }
}