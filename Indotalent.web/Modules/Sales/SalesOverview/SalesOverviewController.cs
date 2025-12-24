using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Web.Modules.Sales.SalesOverview
{
    public class SalesOverviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
