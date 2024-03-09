using Microsoft.AspNetCore.Mvc;

namespace Examination.PL.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
