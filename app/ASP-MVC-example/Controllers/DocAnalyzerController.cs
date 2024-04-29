using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_example.Controllers
{
    public class DocAnalyzerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public bool IsValidDocFileName(string fileName)
        {
            //判斷：不分大小寫
            if (!fileName.EndsWith(".doc", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}
