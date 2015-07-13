using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace Protiviti.Boilerplate.Test.Support
{
    public static class WebDriverExtensions
    {
        public static string GetTextBoxValue(this IWebDriver browser, string field)
        {
            IWebElement control = GetFieldControl(browser, field);

            return control.GetAttribute("value");
        }

        public static void SetTextBoxValue(this IWebDriver browser, string field, string value)
        {
            var control = GetFieldControl(browser, field);
            var wait = new WebDriverWait(browser, SeleniumController.DefaultTimeout);
            if (!String.IsNullOrEmpty(control.GetAttribute("value")))
            {
                control.Clear();
                wait.Until(_ => String.IsNullOrEmpty(control.GetAttribute("value")));
            }

            control.SendKeys(value);
            //            wait.Until( _ => control.Value == value);
            System.Threading.Thread.Sleep(100);
        }

        public static void SubmitForm(this IWebDriver browser, string formId = null)
        {
            var form = formId == null ? GetForm(browser) : browser.FindElements(By.Id(formId)).First();
            form.Submit();
            System.Threading.Thread.Sleep(100);
        }

        public static void ClickButton(this IWebDriver browser, string buttonId)
        {
            browser.FindElements(By.Id(buttonId)).First().Click();
        }

        private static IWebElement GetFieldControl(IWebDriver browser, string field)
        {
            var form = GetForm(browser);
            return form.FindElement(By.Id(field));
        }

        private static IWebElement GetForm(IWebDriver browser)
        {
            return browser.FindElements(By.TagName("form")).First();
        }

        public static void NavigateTo(this IWebDriver browser, string relativeUrl)
        {
            browser.Navigate().GoToUrl(new Uri(new Uri(ConfigurationManager.AppSettings["AppUrl"]), relativeUrl));
        }

        public static string GetFullAbsoluteUri(this IWebDriver browser, string relativeUrl)
        {
            return (new Uri(new Uri(ConfigurationManager.AppSettings["AppUrl"]), relativeUrl).AbsoluteUri);
        }

        public static DropDown GetDropDown(this IWebDriver browser, string id)
        {
            return browser.FindElement(By.Id(id)).AsDropDown();
        }

        public static DropDown AsDropDown(this IWebElement e)
        {
            return new DropDown(e);
        }

        public class DropDown
        {
            private readonly IWebElement dropDown;

            public DropDown(IWebElement dropDown)
            {
                this.dropDown = dropDown;

                if (dropDown.TagName != "select")
                    throw new ArgumentException("Invalid web element type");
            }

            public string SelectedValue
            {
                get
                {
                    var selectedOption = dropDown.FindElements(By.TagName("option")).Where(e => e.Selected).FirstOrDefault();
                    if (selectedOption == null)
                        return null;

                    return selectedOption.GetAttribute("value");

                }
                set
                {
                    new SelectElement(dropDown).SelectByValue(value);
                }
            }
        }
       
        public static bool WaitUntilElementIsPresent(this IWebDriver driver, By by, int timeout = 30)
        {
            for (var i = 0; i < timeout; i++)
            {
                if (driver.ElementIsPresent(by)) return true;
                Thread.Sleep(200);
            }
            return false;
        }
        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// This function takes the screenshot and saves the file into Debug folder with file name as Scenario Name_MethodName
        /// </summary>
           public static void TakeScreenshot(this IWebDriver driver, string saveLocation)
        {
            try
            {
                ITakesScreenshot ssdriver = driver as ITakesScreenshot;
                Screenshot screenshot = ssdriver.GetScreenshot();
                String Filename = saveLocation + "Test.png";
                screenshot.SaveAsFile(Filename, ImageFormat.Png);
            }
            catch
            {
                throw new Exception("unable to take the screenshot");
            }
            
        }

           /// <summary>
           /// This function gets the current method name which is executing
           /// </summary>
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        /// <summary>
        /// This function gets the name of the scenario running currently
        /// </summary>
        public static string GetCurrentScenario()
        {
            String title = ScenarioContext.Current.ScenarioInfo.Title;
            return title;
        }

    }
}
