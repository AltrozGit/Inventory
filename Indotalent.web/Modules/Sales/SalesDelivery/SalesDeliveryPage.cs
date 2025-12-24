using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Sales.Pages
{

    [PageAuthorize(typeof(SalesDeliveryRow))]
    public class SalesDeliveryController : Controller
    {
        [Route("Sales/SalesDelivery")]
        public ActionResult Index()
        {
            return View("~/Modules/Sales/SalesDelivery/SalesDeliveryIndex.cshtml");
        }
    }
}