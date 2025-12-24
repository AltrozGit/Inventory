using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Sales.Pages
{

    [PageAuthorize(typeof(SalesDeliveryDetailRow))]
    public class SalesDeliveryDetailController : Controller
    {
        [Route("Sales/SalesDeliveryDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Sales/SalesDeliveryDetail/SalesDeliveryDetailIndex.cshtml");
        }
    }
}