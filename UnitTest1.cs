using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PastebinAutomation.Pages;
using System;

namespace PastebinAutomation.Tests
{
    public class PastebinTests
    {
        private IWebDriver Driver;
        private HomePage HomePage;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://pastebin.com/");
            HomePage = new HomePage(Driver);
        }

        [Test]
        public void CreateNewPasteTest()
        {
            string code = "git config --global user.name  \"New Sheriff in Town\"\r\ngit reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\r\ngit push origin master --force\r\n";

            HomePage.EnterCode(code);
            //Thread.Sleep(5000);
            HomePage.SelectSyntax("Bash");
            //Thread.Sleep(5000);
            HomePage.SelectExpiration("10 Minutes");
            //Thread.Sleep(5000);
            HomePage.EnterPasteName("how to gain dominance among developers");
            //Thread.Sleep(5000);
            HomePage.SubmitPaste();

            Assert.IsTrue(Driver.Title.Contains("how to gain dominance among developers"));

            string selectedSyntax = HomePage.GetSelectedSyntax();
            Assert.IsTrue(selectedSyntax.Contains("Bash"), $"Expected 'Bash', but found '{selectedSyntax}'");

            //[To Do]
            //string inputedCode = HomePage.GetPastedCodeInput();
            //Assert.IsTrue(inputedCode.Contains(code),
            //    $"Expected '{code}', but found '{inputedCode}'");
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}

