using OpenQA.Selenium;
using Locators = TestStack.Seleno.PageObjects.Locators;

namespace MvcTesting.Tests.PageObjects
{
    /// <summary>
    /// Base class for Page Object classes
    /// </summary>
    public class BaseTestPage : TestStack.Seleno.PageObjects.Page
    {
        internal void NavigateTo(string url) => Navigate.To<BaseTestPage>(url);

        internal void ExecuteScript(string script) => Execute.Script(script);
        
        protected IWebElement FindById(string id) => Find.Element(By.Id(id));

        protected IWebElement FindByTag(string tag) => Find.Element(By.TagName(tag));

        protected IWebElement FindByClass(string className) => Find.Element(By.ClassName(className));

        protected IWebElement FindBySelector(string selector) => Find.Element(By.CssSelector(selector));

        protected IWebElement FindByjQuery(string selector) => Find.Element(Locators.By.jQuery(selector));
    }
}
