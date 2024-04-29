using ASP_MVC_example.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ASP_MVC_example.test
{
    public class LogAnalyzerTest
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzerController analyzer = new LogAnalyzerController();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.txt");
            Assert.That(result, Is.False); // Expect: False
        }

        [Test]
        public void IsValidLogFileName_goodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzerController analyzer = new LogAnalyzerController();
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.LOG");
            Assert.That(result, Is.True); // Expect: True
        }
    }
}
