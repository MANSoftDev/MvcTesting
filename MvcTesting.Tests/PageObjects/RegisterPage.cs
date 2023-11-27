using System.Threading;
using TestStack.Seleno.PageObjects.Locators;

namespace MvcTesting.Tests.PageObjects
{
    /// <summary>
    /// Encapsulate functionality for Registration page
    /// </summary>
    public class RegisterPage : BaseTestPage
    {
        private string m_Email;
        private string m_Password;
        private string m_ConfirmPassword;

        /// <summary>
        /// Submit registration form
        /// </summary>
        public void Submit()
        {
            var submit = FindBySelector("input[type=submit]");
            submit.Click();
        }

        /// <summary>
        /// Get form action text
        /// </summary>
        public string FormAction
        {
            get { return FindByTag("form").GetAttribute("action"); }
        }

        /// <summary>
        /// Get/set email
        /// Input to email textbox on form
        /// </summary>
        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
                var element = FindById("Email");
                element.Clear();
                element.SendKeys(value);
            }
        }

        /// <summary>
        /// Get/set password
        /// Input to password textbox on form
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set
            {
                m_Password = value;
                var element = FindById("Password");
                element.Clear();
                element.SendKeys(value);
            }
        }

        /// <summary>
        /// Get/set confirm password
        /// Input to confirm password textbox on form
        /// </summary>
        public string ConfirmPassword
        {
            get { return m_ConfirmPassword; }

            set
            {
                m_ConfirmPassword = value;
                var element = FindById("ConfirmPassword");
                element.Clear();
                element.SendKeys(value);
            }
        }

        /// <summary>
        /// Check if validation errors are displayed
        /// </summary>
        public bool IsValidationErrorDisplayed
        {
            get {  return FindByjQuery("div[class$=validation-summary-errors]").Displayed; }
        }

        /// <summary>
        /// Check if email validation error is displayed
        /// </summary>
        public bool IsEmailValidationErrorDisplayed
        {
            get
            {
                var element = FindByjQuery("div[class$=validation-summary-errors] li:first-child");
                return (element.Text == Const.EmailRequired);
            }
        }

        /// <summary>
        /// Check if password validation error is displayed
        /// </summary>
        public bool IsPasswordValidationErrorDisplayed
        {
            get
            {
                var element = FindByjQuery("div[class$=validation-summary-errors] li:first-child");
                return (element.Text == Const.PasswordRequired);
            }
        }

        /// <summary>
        /// Check if password length validation error is displayed
        /// </summary>
        public bool IsPasswordLengthValidationErrorDisplayed
        {
            get
            {
                var element = FindByjQuery("div[class$=validation-summary-errors] li:first-child");
                return (element.Text == Const.PasswordLength);
            }
        }

        /// <summary>
        /// Check if confirm password validation error is displayed
        /// </summary>
        public bool IsConfirmPasswordValidationErrorDisplayed
        {
            get
            {
                var element = FindByjQuery("div[class$=validation-summary-errors] li:first-child");
                return (element.Text == Const.ConfirmPasswordNotMatching);
            }
        }
    }

    public class StronglyTypedRegisterPage : TestStack.Seleno.PageObjects.Page<Models.RegisterViewModel>
    {
        /// <summary>
        /// Submit registration form
        /// </summary>
        public void Submit()
        {
            var submit = Find.Element(By.CssSelector("input[type=submit]"));
            submit.Click();
        }

        /// <summary>
        /// Register a new user with given info
        /// </summary>
        /// <param name="model">RegisterViewModel containing user information</param>
        public void RegisterUser(Models.RegisterViewModel model)
        {
            Input.Model(model);
            
            // Pause to show inputs
            Thread.Sleep(2000);

            // Pause test so data can be entered manually
            //Thread.Sleep(5000);
            // Get input from form
            //var user = Read.ModelFromPage();

            Submit();
        }
    }
}
