using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class GeoDataAutoCompleteSteps
    {
        [Then(@"I should be able to type partial city name")]
public void ThenIShouldBeAbleToTypePartialCityName()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"I should see list of city pulled from rest api")]
public void ThenIShouldSeeListOfCityPulledFromRestApi()
{
    ScenarioContext.Current.Pending();
}
    }
}
