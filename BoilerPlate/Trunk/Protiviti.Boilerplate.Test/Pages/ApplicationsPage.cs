using System.Threading;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;

namespace Protiviti.Boilerplate.Test.Pages
{
    public class ApplicationsPage
    {
        public static bool IsAt()
        {
            var registrationLink = SeleniumController.Instance.Driver.FindElement(By.Id("Applications"));
            if (registrationLink.Text == "Applications")
                return true;
            else
                return false;
        }
        public static bool Has(string elementId)
        {
            if (SeleniumController.Instance.Driver.FindElement(By.Id(elementId)) != null)
                return true;
            else
                return false;
        }
        public static void GoTo(string urlName)
        {
            Initialize();
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ClientUrl + urlName);
            Thread.Sleep(4000);
        }
        public static void Initialize()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ServerUrl + "/breeze/ApplicationWizard/Metadata");
        }
    }
}
