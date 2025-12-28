using Microsoft.AspNetCore.Mvc;

namespace AspSampleChangeLanguage.Controllers
{
    public class CultureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
