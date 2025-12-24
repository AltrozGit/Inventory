using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Sales.Pages
{

    [PageAuthorize(typeof(SalesReturnDetailRow))]
    public class SalesReturnDetailController : Controller
    {
        [Route("Sales/SalesReturnDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Sales/SalesReturnDetail/SalesReturnDetailIndex.cshtml");
        }
    }
}