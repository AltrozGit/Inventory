using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(MaterialReturnDetailRow))]
    public class MaterialReturnDetailController : Controller
    {
        [Route("Material/MaterialReturnDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/MaterialReturnDetail/MaterialReturnDetailIndex.cshtml");
        }
    }
}