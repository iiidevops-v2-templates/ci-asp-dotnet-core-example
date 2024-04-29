using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC_example.Controllers
{
    public class LogAnalyzerController : Controller
    {
        // Remove the unused private field '_logger'
        
        // Constructor
        public LogAnalyzerController()
        {
            // No need to initialize _logger since it's not used anymore
        }

        // Index action method
        public IActionResult Index()
        {
            return View(); // Return a view
        }

        // Method to check if a file name is a valid log file name
        public bool IsValidLogFileName(string fileName)
        {
            // Check if the file name ends with ".log" ignoring case
            if (!fileName.EndsWith(".log", StringComparison.CurrentCultureIgnoreCase))
            {
                return false; // If not, return false
            }

            return true; // If ends with ".log", return true
        }
    }
}
