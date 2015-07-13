using System;
using TechTalk.SpecFlow;

namespace Protiviti.Test.Specflow.Steps
{
    [Binding]
    public class MainNavigationSteps
    {
        [Given(@"I am on the home page")]
public void GivenIAmOnTheHomePage()
{
    ScenarioContext.Current.Pending();
}

        [When(@"I click on the Employee link in the navigation bar")]
public void WhenIClickOnTheEmployeeLinkInTheNavigationBar()
{
    ScenarioContext.Current.Pending();
}

        [Then(@"I should land on the Employee page")]
public void ThenIShouldLandOnTheEmployeePage()
{
    ScenarioContext.Current.Pending();
}
    }
}
