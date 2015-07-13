using Protiviti.Boilerplate.Test.Helper;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class FullTextSearchSteps
    {
        [Then(@"I should see a list of ""(.*)""")]
        public void ThenIShouldSeeAListOf(string p0)
        {
            DriverHelper.GetHeading2ByTitle(p0);
        }
    }
}
