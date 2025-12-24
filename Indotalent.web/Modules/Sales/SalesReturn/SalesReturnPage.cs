using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Sales.Pages
{

    [PageAuthorize(typeof(SalesReturnRow))]
    public class SalesReturnController : Controller
    {
        [Route("Sales/SalesReturn")]
        public ActionResult Index()
        {
            return View("~/Modules/Sales/SalesReturn/SalesReturnIndex.cshtml");
        }
    }
}