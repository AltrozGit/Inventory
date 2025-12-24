using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Material.Pages
{

    [PageAuthorize(typeof(MaterialReturnRow))]
    public class MaterialReturnController : Controller
    {
        [Route("Material/MaterialReturn")]
        public ActionResult Index()
        {
            return View("~/Modules/Material/MaterialReturn/MaterialReturnIndex.cshtml");
        }
    }
}