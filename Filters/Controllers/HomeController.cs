using System.Web.Mvc;

namespace Filters.Controllers
{
    //[CustomActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        //[CustomActionFilter]
        public ActionResult Index()
        {
            return View();
        }

       // [CustomActionFilter]
        public ActionResult Message()
        {
            return Content("Hello World!!!");
        }
    }
}