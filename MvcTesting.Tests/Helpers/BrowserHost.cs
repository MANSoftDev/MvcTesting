using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.Contracts;
using TestStack.Seleno.Configuration.Screenshots;
using TestStack.Seleno.Configuration.WebServers;

namespace MvcTesting.Tests
{
    /// <summary>
    /// Encapsulate SelenoHost functionality
    /// </summary>
    public class BrowserHost : IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BrowserHost()
        {
            Instance = new SelenoHost();

            Instance.Run(
                "MvcTesting", // Name of project folder
                16066, // IISExpress port number to use
                c => c // Configuration settings to use
                .WithRemoteWebDriver(BrowserFactory.Chrome)
                .UsingCamera(Camera)
                .UsingDomCapture(DomCaptureFolder));

            // Use a remote URL
            //InternetWebServer webServer = new InternetWebServer("http://mvctesting20161102101012.azurewebsites.net");
            //Instance.Run("MvcTesting", 16066, c => c
            //    .WithWebServer(webServer)
            //    .WithRemoteWebDriver(BrowserFactory.Chrome)
            //    .UsingCamera(Camera)
            //    .UsingDomCapture(DomCaptureFolder));
        }

        /// <summary>
        /// Navigate to a page
        /// </summary>
        /// <typeparam name="T">Strongly typed page to navigate to</typeparam>
        /// <param name="url">Url to navigate to if specified</param>
        /// <returns>PageObject</returns>
        public T NavigateTo<T>(string url = null) where T : TestStack.Seleno.PageObjects.UiComponent, new()
        {
            return Instance.NavigateToInitialPage<T>(url);
        }

        /// <summary>
        /// Take a screenshot of the current page and save
        /// with given name
        /// </summary>
        /// <param name="name">Name of file to save</param>
        public void TakeScreenshot(string name)
        {
            string fileName = Filename.CreateFilename(name);
            Instance.Application.Camera.TakeScreenshot(fileName);
        }

        /// <summary>
        /// Capture current state of DOM
        /// </summary>
        public void CaptureDom()
        {
            Instance.Application.CaptureDomAndThrow(null, "Testing DOM capture");
        }

        #region Properties

        /// <summary>
        /// Get/Set SelenoHost
        /// </summary>
        private SelenoHost Instance { get; set; }

        /// <summary>
        /// Get a FileCamera
        /// </summary>
        private FileCamera Camera { get; } = new FileCamera(ConfigurationManager.AppSettings["ScreenShotFolder"]);

        private string DomCaptureFolder { get; } = ConfigurationManager.AppSettings["DomFolder"];

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    if(Instance != null)
                    {
                        Instance.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
