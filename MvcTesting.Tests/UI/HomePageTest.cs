using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTesting.Tests.PageObjects;
using System.Threading;
using TestStack.Seleno.Configuration;

namespace MvcTesting.Tests.UI
{
    [TestClass]
    public class HomePageTest
    {
        [TestMethod]
        public void Navitgation_Demo()
        {
            using(BrowserHost host = new BrowserHost())
            {
                HomePage homePage = host.NavigateTo<HomePage>();
                Thread.Sleep(1000); // Delay to see action being performed
                homePage.NavigateTo("Home/About");
                Thread.Sleep(1000);
                homePage.NavigateTo("Home/Contact");
                string script = @"$('.body-content').html('<h1>Hello, SLC .NET Users Group</h1>');";
                homePage.ExecuteScript(script);
            }
        }

        [TestMethod]
        public void Validate_Application_Title()
        {
            using(BrowserHost host = new BrowserHost())
            {
                HomePage homePage = host.NavigateTo<HomePage>();
                Assert.AreEqual<string>(Const.ApplicationName, homePage.ApplicationTitle);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SelenoException))]
        public void Take_Screen_Shot()
        {
            using(BrowserHost host = new BrowserHost())
            {
                host.TakeScreenshot("TakeScreenShot");
                host.CaptureDom();
            }
        }
    }
}
