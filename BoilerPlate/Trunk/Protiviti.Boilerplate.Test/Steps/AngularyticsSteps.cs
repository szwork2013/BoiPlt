using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class AngularyticsSteps
    {
        [Then(@"I should see analytical data")]
public void ThenIShouldSeeAnalyticalData()
{
    ScenarioContext.Current.Pending();
}
    }
}
