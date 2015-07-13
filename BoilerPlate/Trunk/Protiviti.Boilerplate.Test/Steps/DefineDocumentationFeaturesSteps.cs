using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
  [Binding]
  public class DefineDocumentationFeaturesSteps
  {
    [Then(@"I should be able to define a scenario with the following step")]
    public void ThenIShouldBeAbleToDefineAScenarioWithTheFollowingStep(string multilineText)
    {
      return;
    }

    [Then(@"the step should load a browser and point it at the URL that renders the markdown file")]
    public void ThenTheStepShouldLoadABrowserAndPointItAtTheURLThatRendersTheMarkdownFile()
    {
      return;
    }

    [Then(@"the step should verify the current page has an h(.*) with the text specified in the parameter")]
    public void ThenTheStepShouldVerifyTheCurrentPageHasAnHWithTheTextSpecifiedInTheParameter(int p0)
    {
      return;
    }

    [Then(@"the step should verify the page has the specified links before the next h(.*)")]
    public void ThenTheStepShouldVerifyThePageHasTheSpecifiedLinksBeforeTheNextH(int p0)
    {
      return;
    }

    [Then(@"the step should do nothing but pass")]
    public void ThenTheStepShouldDoNothingButPass()
    {
      return;
    }

    [Then(@"the step should verify the current page has an anchor with the text specified in the parameter")]
    public void ThenTheStepShouldVerifyTheCurrentPageHasAnAnchorWithTheTextSpecifiedInTheParameter()
    {
      return;
    }

    [Then(@"the step should verify the current page has an anchor with the text specified in the parameter in the section specified")]
    public void ThenTheStepShouldVerifyTheCurrentPageHasAnAnchorWithTheTextSpecifiedInTheParameterInTheSectionSpecified()
    {
      return;
    }

  }
}
