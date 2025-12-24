using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Bills.Pages
{

    [PageAuthorize(typeof(BillPaymentRow))]
    public class BillPaymentController : Controller
    {
        [Route("Bills/BillPayment")]
        public ActionResult Index()
        {
            return View("~/Modules/Bills/BillPayment/BillPaymentIndex.cshtml");
        }
    }
}