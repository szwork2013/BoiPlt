using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using OpenQA.Selenium;
using System.Threading;
using Protiviti.Boilerplate.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace Protiviti.Boilerplate.Test.Pages
{
    public class DashboardPage
    {


        public static bool IsAt
        {
            get
            {   //Added thread as tests fail when ran in group. 
                //Thread.Sleep(1000);
                //Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.TagName("h4"), 30));
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.TagName("h4"), 30);
                var h4s = SeleniumController.Instance.Driver.FindElements(By.TagName("h4"));
                if (h4s.Count > 0)
                    return h4s[0].Text == "Technology Overview";
                return false;
            }
        }

        private static bool isPageVisible = false;
        /// <summary>
        /// This function checks if the driver is on the Home page URL, and if not,
        /// navigates the driver to the Home page URL by using a static variable isPageVisible and comparing the URL of current webPage 
        /// </summary>
        public static void HomePagePresent()
        {
            string PageUrl = SeleniumController.Instance.Driver.Url;
            if (!isPageVisible)
            {
                DashboardPage.GoTo();
                isPageVisible = true;
            }
            else if (isPageVisible == true && PageUrl != "http://localhost/Protiviti.Boilerplate.Client/#/")
            {
                DashboardPage.GoTo();
            }
        }

        public static void SelectLink(string dashLink)
        {
            //Added thread as tests fail when ran in group. 
            Thread.Sleep(2000);
            string currentWindow = SeleniumController.Instance.Driver.CurrentWindowHandle;
            var link = SeleniumController.Instance.Driver.FindElement(By.LinkText(dashLink));
            link.Click();
            SeleniumController.SleepWaitTime(3000);
            IList<string> allWindows = SeleniumController.Instance.Driver.WindowHandles;
            int wincount = allWindows.Count();
            for (int i = 0; i < wincount; i++)
            {
                if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains(dashLink))
                {
                    SwitchWindow(currentWindow);
                }
                else if (dashLink.Contains("AngularJs"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("AngularJS"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Asp.Net WebApi (CORS, Attribute Routing)"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("ASP.NET Web API"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Typescript"))
                {
                    SeleniumController.SleepWaitTime(150000);
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("TypeScript"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Owin"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("OWIN"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Breezejs"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("breeze"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Bootstrap"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("Bootstrap"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);

                }
                else if (dashLink.Contains("Entity Framework"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("Entity Framework"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Katana"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("Katana"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Semantic Logging"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("Semantic Logging"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }
                else if (dashLink.Contains("Asp.Net Identity"))
                {
                    if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[i]).Title.Contains("ASP.NET Identity"))
                    {
                        SwitchWindow(currentWindow);
                    }
                    else
                        ErrorLoadingPage(currentWindow);
                }

            }
        }

        public static void ErrorLoadingPage(string currentWindow)
        {
            IList<string> allWindows = SeleniumController.Instance.Driver.WindowHandles;
            int wincount = allWindows.Count();
                if (SeleniumController.Instance.Driver.SwitchTo().Window(allWindows[1]).Title.Contains("Problem loading page"))
                {
                    SwitchWindow(currentWindow);
                }
           
            
        }

        public static void SwitchWindow(string currentWindow)
        {
            SeleniumController.SleepWaitTime(5000);
            SeleniumController.Instance.Driver.Close();
            SeleniumController.SleepWaitTime(6000);
            SeleniumController.Instance.Driver.SwitchTo().Window(currentWindow);
            SeleniumController.WaitTime("div.panel-body");
       }

        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/");
            Thread.Sleep(1000);
        }

        public static void SelectTab(string tabName) //updated from being a void method 
        {
            //Thread.Sleep(1000);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("topnav"), 30);
            var topNavBar = SeleniumController.Instance.Driver.FindElement(By.Id("topnav"));
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.TagName("a"), 30);
            var selectedPageTab = topNavBar.FindElements(By.TagName("a"));

            if (tabName == "Employees")
            {
                LoginPage.ClickLoginButtonMenuBar();
                LoginPage.AdminLoginUsername();
                LoginPage.AdminLoginPassword();
                LoginPage.ClickLoginButton();
                // SeleniumController.SleepWaitTime(2000);
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("topnav"), 30);
                var topNavBar1 = SeleniumController.Instance.Driver.FindElement(By.Id("topnav"));
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.TagName("a"), 30);
                var selectedPageTab1 = topNavBar.FindElements(By.TagName("a"));
                foreach (var subHeading in selectedPageTab1)
                {
                    if (subHeading.Text == tabName)
                    {
                        subHeading.Click();
                        break;
                    }

                }
            }
            else if (tabName == "CDS Initiatives (Nav Demo)")
            {
                Thread.Sleep(1000);
                IWebElement Initiative = SeleniumController.Instance.Driver.FindElement(By.Id("initiatives"));
                Initiative.Click();
            }

            else if (tabName == "GridDemo")
            {
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("viewmenu"), 30);
                IWebElement View = SeleniumController.Instance.Driver.FindElement(By.Id("viewmenu"));
                View.Click();
                WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("gridDemo"), 30);
                IWebElement GridDemo = SeleniumController.Instance.Driver.FindElement(By.Id("gridDemo"));
                GridDemo.Click();
            }
            else
            {

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

        public static bool HeaderIsDisplayed()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("dashboard"), 30);
            var headerTab = SeleniumController.Instance.Driver.FindElement(By.Id("dashboard"));
            if (headerTab.Text == "Dashboard")
                return true;
            else
                return false;
        }
    }
}


