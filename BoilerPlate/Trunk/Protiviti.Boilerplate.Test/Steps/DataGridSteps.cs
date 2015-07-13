using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Helper;
using Protiviti.Boilerplate.Test.Pages;
using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Support;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class DataGridSteps
    {
        [Then(@"I should see a ""(.*)"" grid")]
        public void ThenIShouldSeeAGrid(string p0)
        {
            SeleniumController.SleepWaitTime(2000);
            DriverHelper.GetHeading2ByTitle(p0);
        }

        [Then(@"I click on ""(.*)"" column header")]
        public void ThenIClickOnColumnHeader(string p0)
        {
            DriverHelper.GetElementByLinkText(p0).Click();
        }
    }
}
