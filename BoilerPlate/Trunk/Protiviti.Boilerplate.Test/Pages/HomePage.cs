using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Protiviti.Boilerplate.Test.Pages
{
    public class HomePage
    {
        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/");
            SeleniumController.SleepWaitTime(2000);
        }
        public static bool IsAt
        {
            get
            {
                var h4s = SeleniumController.Instance.Driver.FindElements(By.TagName("h4"));
                if (h4s.Count > 0)
                    return h4s[0].Text == "Technology Overview";
                return false;
            }
        }
        public static void SelectTab(string tabName)
        {
           // bool Appears = SeleniumController.Instance.Driver.ElementIsPresent(By.Id("topnav"));
            bool Appears = WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver,By.Id("topnav"), 30);
            if (Appears)
            {
                var topNavBar = SeleniumController.Instance.Driver.FindElement(By.Id("topnav"));
                var selectedPageTab = topNavBar.FindElements(By.TagName("a"));
                foreach (var subHeading in selectedPageTab)
                {
                    if (subHeading.Text == tabName)
                    {
                        subHeading.Click();
                        break;
                    }
                }
            }
            
        }
    }
}
