using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTesting.Tests.PageObjects;
using System.Threading;
using MvcTesting.Controllers;

namespace MvcTesting.Tests.UI
{
    [TestClass]
    public class RegistrationTest
    {
        [TestMethod]
        public void Navigate_To_Register_Page()
        {
            using(BrowserHost host = new BrowserHost())
            {
                HomePage homePage = host.NavigateTo<HomePage>();
                RegisterPage page = homePage.GoToRegisterPage();

                // Make sure navigation to Register page is successful by checking form action
                Assert.IsTrue(page.FormAction.EndsWith(Const.FormAction));
            }
        }

        [TestMethod]
        public void Register_New_User()
        {
            using(BrowserHost host = new BrowserHost())
            {
                HomePage homePage = host.NavigateTo<HomePage>();
                RegisterPage page = homePage.GoToRegisterPage();

                page.Submit();

                // No values have been entered so validation should fail
                Assert.IsTrue(page.IsValidationErrorDisplayed, Const.ValidationNotDisplayed);

                PasswordValidation(page);

                PasswordLength(page);

                PasswordConfiramtion(page);

                // Many more validation scenarios that could be tested...

                page.ConfirmPassword = Const.DefaultPassword;
                page.Submit();

                // Pause to allow registration to commit and page to be redirected
                Thread.Sleep(2000);

                // Although started on registration page, application has been redirected to home page
                // and test is for element on home page
                Assert.IsTrue(homePage.LoginName.Contains(page.Email), Const.ValidationRegistrationNotComplete);
            }
        }

        [TestMethod]
        public void Strongly_Typed_Register_New_User()
        {
            using(BrowserHost host = new BrowserHost())
            {
                StronglyTypedRegisterPage page = host.NavigateTo<StronglyTypedRegisterPage>("/Account/Register");

                Models.RegisterViewModel model = new Models.RegisterViewModel()
                {
                    Email = GenerateUnqiueEmail(),
                    Password = Const.DefaultPassword,
                    ConfirmPassword = Const.DefaultPassword
                };

                page.RegisterUser(model);
            }
        }

        #region Private Methods

        /// <summary>
        /// Check for password validation message
        /// </summary>
        /// <param name="page">PageObject to use</param>
        private static void PasswordValidation(RegisterPage page)
        {
            page.Email = GenerateUnqiueEmail();
            page.Submit();

            // Make sure password validation is displayed
            Assert.IsTrue(page.IsPasswordValidationErrorDisplayed, Const.ValidationPassword);
        }

        /// <summary>
        /// Check for password length validation message
        /// </summary>
        /// <param name="page">PageObject to use</param>
        private static void PasswordLength(RegisterPage page)
        {
            page.Password = "p";
            page.Submit();

            // Make sure password length validation is displayed
            Assert.IsTrue(page.IsPasswordLengthValidationErrorDisplayed, Const.ValidationPasswordLength);
        }

        /// <summary>
        /// Check for password confirmation message
        /// </summary>
        /// <param name="page">PageObject to use</param>
        private static void PasswordConfiramtion(RegisterPage page)
        {
            page.Password = Const.DefaultPassword;
            page.Submit();

            // Make sure confirm password validation is displayed
            Assert.IsTrue(page.IsConfirmPasswordValidationErrorDisplayed, Const.ValidationPasswordConfirm);
        }

        /// <summary>
        /// Generate a random email address
        /// </summary>
        /// <returns>Email address</returns>
        private static string GenerateUnqiueEmail()
        {
            string ticks = DateTime.Now.Ticks.ToString();
            return $"{ticks.Substring(ticks.Length - 6)}@test.com";
        }

        #endregion
    }
}
