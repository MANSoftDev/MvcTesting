using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTesting.Tests
{
    /// <summary>
    /// Consolidate and define strings used in the applications
    /// </summary>
    public class Const
    {
        public const string ApplicationName = "MVC Testing";
        public const string FormAction = "/Account/Register";
        public const string DefaultPassword = "P@ssw0rd";

        #region Assert Messages

        public const string ValidationNotDisplayed = "Validation errors not displayed";
        public const string ValidationPassword = "Password validation error message not displayed";
        public const string ValidationPasswordLength = "Password length validation error message not displayed";
        public const string ValidationPasswordConfirm = "Confirm password validation error message not displayed";
        public const string ValidationRegistrationNotComplete = "Registration not complete";

        #endregion

        #region Validation Error Text

        public const string EmailRequired = "The Email field is required.";
        public const string PasswordRequired = "The Password field is required.";
        public const string ConfirmPasswordNotMatching = "The password and confirmation password do not match.";
        public const string PasswordLength = "The Password must be at least 6 characters long.";

        #endregion
    }
}
