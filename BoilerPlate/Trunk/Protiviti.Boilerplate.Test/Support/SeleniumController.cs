using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Protiviti.Boilerplate.Test.Support
{
    public class SeleniumController
    {
        public static SeleniumController Instance = new SeleniumController();

        private IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    Start();
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        private void Trace(string message)
        {
            Console.WriteLine("-> {0}", message);
        }

        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(500);

        public void Start()
        {


            //capability.Platform(Platform.CurrentPlatform);
            if (driver != null)
                return;

#if VISIBLEBROWSER

            driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();

#else
      driver = new PhantomJSDriver();
#endif
            // Selenium = new InternetExplorerDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(DefaultTimeout);
            Driver.Manage().Window.Maximize();
            //            Selenium = new DefaultSelenium("localhost", 4444, "*chrome", appUrl);
            //            Selenium.Start();
            Trace("Selenium started");

        }

        public void Stop()
        {
            if (driver == null)
                return;

            try
            {
                driver.Quit();
                driver.Dispose();

                //Selenium.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            driver = null;
            Trace("Selenium stopped");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        public static void WaitTime(String condition)
        {
            //Switch("RAD_SPLITTER_PANE_EXT_CONTENT_ContentPane");
            try
            {
                WebDriverWait wait = new WebDriverWait(SeleniumController.Instance.Driver, TimeSpan.FromMinutes(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(condition)));
            }
            catch
            {

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stime"></param>
        public static void SleepWaitTime(int stime)
        {
            try
            {

                Thread.Sleep(stime);
            }

            catch
            {

            }

        }


        ///<summary>
        ///Checks the url of the page for current test case
        public static void CheckUrlOfPage(string url)
        {
            String currenturl = SeleniumController.Instance.Driver.Url;

            if (currenturl != url)
            {
                for (int i = 0; i < 6; i++)
                {
                    Thread.Sleep(3000);
                    CheckUrlOfPage(url);
                }
            }
        }

    }
}
