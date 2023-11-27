using TestStack.Seleno.PageObjects.Locators;

namespace MvcTesting.Tests.PageObjects
{
    /// <summary>
    /// Encapsulate functionality for home page
    /// </summary>
    public class HomePage : BaseTestPage
    {
        /// <summary>
        /// Navigate to registration page.
        /// </summary>
        /// <remarks>Could be in RegisterPage, but for demo purposes include here</remarks>
        /// <returns>RegisterPage object</returns>
        public RegisterPage GoToRegisterPage() => Navigate.To<RegisterPage>(By.LinkText("Register"));

        /// <summary>
        /// Get application title text
        /// </summary>
        public string ApplicationTitle
        {
            get { return FindByClass("navbar-brand").Text; }
        }

        /// <summary>
        /// Get login name displayed
        /// </summary>
        public string LoginName
        {
            get { return FindByjQuery("a[title=Manage]").Text; }
        }
    }
}
