using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Pages;
using System.Collections.Generic;

namespace Protiviti.Boilerplate.Test
{
    [Binding]
    public class DashboardSteps
    {
        [Given(@"I navigate to the boilerplate site")]
        public void GivenINavigateToTheBoilerplateSite()
        {
            DashboardPage.HomePagePresent();
            Assert.IsTrue(DashboardPage.IsAt, "Failed to Navigate to Dashboard Page.");

        }

        [Then(@"the Dashboad page is displayed")]
        public void ThenTheDashboadPageIsDisplayed()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to Navigate to Dashboard Page.");
        }

        [Then(@"I can click ""(.*)"" in the Technology Overview table on the Dashboard page")]
        public void ThenICanClickEntityFrameworkInTheTechnologyOverviewTableOnTheDashboardPage(string dashLink)
        {
            DashboardPage.SelectLink(dashLink);
            Assert.IsTrue(DashboardPage.IsAt, "Failed to Navigate to Dashboard Page.");
        }

       
        [Then(@"the main navigation header bar is displayed")]
        public void ThenTheMainNavigationHeaderBarIsDisplayed()
        {
            Assert.IsTrue(DashboardPage.HeaderIsDisplayed(), "Header is not displayed.");
        }
    }
}

