using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protiviti.Boilerplate.Test.Helper;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class ServerQuerySteps
    {
        [Then(@"I should see a ""(.*)"" table")]
        public void ThenIShouldSeeATable(string p0)
        {
            Assert.IsTrue(DriverHelper.HasElementById(p0), "Result table is not loaded.");
        }
    }
}
