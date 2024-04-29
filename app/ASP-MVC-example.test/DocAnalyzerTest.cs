using ASP_MVC_example.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_MVC_example.test
{
    public class DocAnalyzerTest
    {
        [TestCase("TEST.log",false)]
        [TestCase("TEST.txt",false)]
        [TestCase("TEST.doc", true)]
        public void IsValidDocFileName_BadExtension_ReturnsFalse(string filename,bool expected)
        {
            DocAnalyzerController analyzer = new DocAnalyzerController();
            bool result = analyzer.IsValidDocFileName(filename);
            Assert.That(result, Is.EqualTo(expected)); //預期：False。當發生非預期，就會Error，表示程式寫錯
        }
    }
}
