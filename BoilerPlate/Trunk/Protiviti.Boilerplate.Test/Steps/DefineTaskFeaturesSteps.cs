using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
  [Binding]
  public class DefineTaskFeaturesSteps
  {
    [Given(@"I have access to the solution")]
    public void GivenIHaveAccessToTheSolution()
    {
      return;
    }

    [Given(@"the solution has a Features/tasks\.json file")]
    public void GivenTheSolutionHasAFeaturesTasks_JsonFile()
    {
      return;
    }

    [Given(@"the file has the following format for a task")]
    public void GivenTheFileHasTheFollowingFormatForATask(string format)
    {
      return;
    }

    [When(@"I define a step like this")]
    public void WhenIDefineAStepLikeThis(string step)
    {
      return;
    }

    [When(@"^I end the step with --TASK$")]
    public void WhenIEndTheStepWith_TASK()
    {
      return;
    }

    [When(@"I specify a status of (.*) in the task list")]
    public void WhenISpecifyAStatusOfPendingInTheTaskList(string status)
    {
      return;
    }

    [When(@"I run the step")]
    public void WhenIRunTheStep()
    {
      return;
    }

    [Then(@"the step should return a value of (.*)")]
    public void ThenTheStepShouldReturnAValueOfPending(string status)
    {
      return;
    }

    [Given(@"I have some precondition")]
    public void GivenIHaveSomePrecondition()
    {
      return;
    }
  }
}
