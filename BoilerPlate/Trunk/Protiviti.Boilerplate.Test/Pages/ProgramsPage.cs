using System.Threading;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;

namespace Protiviti.Boilerplate.Test.Pages
{
    public class ProgramsPage
    {
        public static bool IsAt()
        {
            var registrationLink = SeleniumController.Instance.Driver.FindElement(By.Id("Programs"));
            if (registrationLink.Text == "Programs")
                return true;
            else
                return false;
        }
        
        public static void GoTo(string urlName)
        {
            Initialize();
            Thread.Sleep(2000);
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ClientUrl + urlName);
            Thread.Sleep(4000);
        }

        public static void Initialize()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl(TestSettings.Instance.ServerUrl + "/breeze/ApplicationWizard/Metadata");
        }
    }
}
