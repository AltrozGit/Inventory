using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace Indotalent.Reminder.Pages
{

    [PageAuthorize(typeof(BulkEmailFileUploadRow))]
    public class BulkEmailFileUploadController : Controller
    {
        [Route("Reminder/BulkEmailFileUpload")]
        public ActionResult Index()
        {
            return View("~/Modules/Reminder/BulkEmailFileUpload/BulkEmailFileUploadIndex.cshtml");
        }
    }
}