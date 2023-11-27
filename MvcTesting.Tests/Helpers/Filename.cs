using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTesting.Tests
{
    /// <summary>
    /// Helper to create unique filenames
    /// </summary>
    public class Filename
    {
        /// <summary>
        /// Create unique file name
        /// </summary>
        /// <param name="name">Name to use to create filename</param>
        public static string CreateFilename(string name)
        {
            return CreateFileName(name);
        }

        #region Private Methods

        /// <summary>
        /// Create a filename using the given test name and the current date
        /// </summary>
        /// <param name="testName">Name of test to add to filename</param>
        /// <returns>Fully qualified filename</returns>
        private static string CreateFileName(string testName)
        {
            string path = ConfigurationManager.AppSettings["ScreenShotFolder"];
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            int fileVersion = 1;
            string fileName = string.Format($"{path}\\{testName}_{DateToString()}.png");
            while(File.Exists(fileName))
            {
                fileName = string.Format($"{path}\\{testName}_{DateToString()}_({fileVersion++}).png");
            };

            return fileName;
        }

        /// <summary>
        /// Convert Date to a usable string format
        /// </summary>
        /// <returns></returns>
        private static string DateToString() => DateTime.Today.ToShortDateString().Replace("/", "_");

        #endregion
    }
}
