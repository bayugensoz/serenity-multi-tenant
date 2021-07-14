using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SerenMulti.Northwind.Pages
{

    [PageAuthorize(typeof(Entities.TagsRow))]
    public class TagsController : Controller
    {
        [Route("Northwind/Tags")]
        public ActionResult Index()
        {
            return View("~/Modules/Northwind/Tags/TagsIndex.cshtml");
        }
    }
}