using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PastebinAutomation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver Driver;
        private readonly By codeInput = By.Id("postform-text");
        private readonly By syntaxHighlighting = By.Id("select2-postform-format-container");
        private readonly By expirationDropdown = By.Id("select2-postform-expiration-container");
        private readonly By pasteNameInput = By.Id("postform-name");
        private readonly By submitButton = By.XPath("//button[contains(text(), 'Create New Paste')]");
        private readonly By selectedSyntaxDisplay = By.CssSelector("a.btn.-small.h_800");

        //[To Do]
        //private readonly By goToPastedCodeInput = By.CssSelector("a.btn.-small");
        //private readonly By pastedCodeInput = By.CssSelector("[pre]");

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void EnterCode(string code)
        {
            Driver.FindElement(codeInput).SendKeys(code);
        }

        public void SelectSyntax(string syntax)
        {
            Driver.FindElement(syntaxHighlighting).Click();
            var syntaxOption = Driver.FindElement(By.XPath($"//li[contains(text(), '{syntax}')]"));
            syntaxOption.Click();
        }

        public void SelectExpiration(string expiration)
        {
            Driver.FindElement(expirationDropdown).Click();
            var expirationOption = Driver.FindElement(By.XPath($"//li[contains(text(), '{expiration}')]"));
            expirationOption.Click();
        }

        public void EnterPasteName(string pasteName)
        {
            Driver.FindElement(pasteNameInput).SendKeys(pasteName);
        }

        public void SubmitPaste()
        {
            Driver.FindElement(submitButton).Click();
        }

        public string GetSelectedSyntax()
        {
            return Driver.FindElement(selectedSyntaxDisplay).Text;
        }

        //[To Do]
        //public string GetPastedCodeInput()
        //{
        //    Driver.FindElement(goToPastedCodeInput).Click();
        //    return Driver.FindElement(pastedCodeInput).Text;
        //}
    }
}
