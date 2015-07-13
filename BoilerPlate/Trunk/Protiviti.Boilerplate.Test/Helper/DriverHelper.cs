using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Helper
{
    public class DriverHelper
    {
        public static IWebElement GetElementById(string value)
        {
            return SeleniumController.Instance.Driver.FindElement(By.Id(value));
        }

        public static IWebElement GetElementByName(string value)
        {
            return SeleniumController.Instance.Driver.FindElement(By.Name(value));
        }

        public static IWebElement GetElementByLinkText(string value)
        {
            return SeleniumController.Instance.Driver.FindElement(By.LinkText(value));
        }

        public static IWebElement GetHeadingByTitle(string title)
        {
            IWebElement found = null;
            var subHeadings = SeleniumController.Instance.Driver.FindElements(By.TagName("h1"));
            foreach (var subHeading in subHeadings)
            {
                if (subHeading.Text == title)
                    found = subHeading;
            }
            return found;
        }

        public static IWebElement GetHeading2ByTitle(string title)
        {
            SeleniumController.SleepWaitTime(2000);
            IWebElement found = null;
            var subHeadings = SeleniumController.Instance.Driver.FindElements(By.TagName("h2"));
            foreach (var subHeading in subHeadings)
            {
                if (subHeading.Text == title)
                    found = subHeading;
            }
            return found;
        }

        public static bool HasElementById(string value)
        {
            if (GetElementById(value) != null)
                return true;
            else
                return false;
        }

        public static bool HasElementByName(string value)
        {
            if (GetElementByName(value) != null)
                return true;
            else
                return false;
        }

        public static bool HasElementByLinkText(string value)
        {
            if (GetElementByLinkText(value) != null)
                return true;
            else
                return false;
        }

        public static void NavigateToDocumentationUrl(string url)
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.DocsUrl + "/" + url);
        }

        public static void NavigateToServerUrl(string url)
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ServerUrl + "/" + url);
        }
    }
}
