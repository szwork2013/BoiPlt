using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Protiviti.Boilerplate.Test.Helper;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class SearchEntityListUIServiceSteps
    {
        [When(@"I make a call to ""(.*)"" page")]
        public void WhenIMakeACallToPage(string p0)
        {
            ProgramsPage.GoTo(p0);
        }

        [Then(@"I should see a list of programs")]
        public void ThenIShouldSeeAListOfPrograms()
        {
            Assert.IsTrue(ProgramsPage.IsAt(), "Failed to load programs.");
        }

        [Then(@"I should see results in a table ""(.*)""")]
        public void ThenIShouldSeeResultsInATable(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Result table is not loaded.");
        }

        [Then(@"I should see name column ""(.*)""")]
        public void ThenIShouldSeeNameColumn(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Programs result table does not have name column.");
        }

        [Then(@"I should see code column ""(.*)""")]
        public void ThenIShouldSeeCodeColumn(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Programs result table does not have code column.");
        }

        [Then(@"I should see cost column ""(.*)""")]
        public void ThenIShouldSeeCostColumn(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Programs result table does not have cost column.");
        }

        [Then(@"I should see duration column ""(.*)""")]
        public void ThenIShouldSeeDurationColumn(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Programs result table does not have duration column.");
        }

        [Then(@"I should see location column ""(.*)""")]
        public void ThenIShouldSeeLocationColumn(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Programs result table does not have location column.");
        }

    }
}
