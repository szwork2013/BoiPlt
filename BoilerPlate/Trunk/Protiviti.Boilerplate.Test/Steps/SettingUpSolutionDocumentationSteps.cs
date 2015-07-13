using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class SettingUpSolutionDocumentationSteps
    {
    [Given(@"I am I have not solution setup")]
    public void GivenIAmIHaveNotSolutionSetup()
    {
        ScenarioContext.Current.Pending();
    }

    [When(@"I view the solution Setup instruction document")]
    public void WhenIViewTheSolutionSetupInstructionDocument()
    {
        ScenarioContext.Current.Pending();
    }

    [Then(@"I should see instructions on how to get solution")]
    public void ThenIShouldSeeInstructionsOnHowToGetSolution()
    {
        ScenarioContext.Current.Pending();
    }

    [Then(@"Trouble shooting tips")]
    public void ThenTroubleShootingTips()
    {
        ScenarioContext.Current.Pending();
    }
    }
}
