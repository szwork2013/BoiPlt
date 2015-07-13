using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Support.SiteValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace Protiviti.Boilerplate.Test.Steps
{
  [Binding]
  public class ValidateDocumentationSteps
  {
    Uri documentationPage = null;
    SiteValidator validator = new SiteValidator();

    [Given(@"I have a documentation page ""([^""]+)"" at ""([^""]+)""")]
    public void GivenIHaveADocumentationPage(string condition, string relativePath)
    {
      documentationPage = new Uri(TestSettings.Instance.DocsUrl + relativePath);
    }

    [Given(@"the page has ""(.*)"" tagged as the (.*)")]
    public void WhenThePageHasTaggedAsTheOwner(string personName, string role)
    {
      return;
    }

    [Given(@"the test settings have ""(.*)"" set as the default reviewer")]
    public void GivenTheTestSettingsHaveSetAsTheDefaultReviewer(string reviewer)
    {
      TestSettings.Instance.DefaultDocumentationReviewer = reviewer;
    }

    [Given(@"the test settings are missing a default reviewer")]
    public void GivenTheTestSettingsAreMissingADefaultReviewer()
    {
      TestSettings.Instance.DefaultDocumentationReviewer = null;
    }
    [Given(@"the test settings have ""(.*)"" set as the current sprint")]
    public void GivenTheTestSettingsHaveSetAsTheCurrentSprint(string sprint)
    {
      TestSettings.Instance.CurrentSprint = sprint;
    }

    [Given(@"the test settings have ""(.*)"" months set at the oldest review date")]
    public void GivenTheTestSettingsHaveMonthsSetAtTheOldestReviewDate(int months)
    {
      TestSettings.Instance.ValidReviewAgeInMonths = months;
    }
    [Given(@"the test settings have a ""(.*)"" priority for resolving ""(.*)"" errors")]
    public void GivenTheTestSettingsHaveAPriorityForResolvingErrors(string priority, string errorType)
    {
      if (!TestSettings.Instance.ErrorResolutionPriorities.Keys.Contains(errorType))
        throw new Exception("The error type of '" + errorType + "' was not in the ErrorResolutionPriorties collection.");
      TestSettings.Instance.ErrorResolutionPriorities[errorType] = priority;
    }

    [When(@"I validate the page")]
    public void WhenIValidateThePage()
    {
      var docPageValidator = new DocPageValidator();
      validator.RegisterPageValidator(docPageValidator);
      validator.RegisterBadLinkResolver(docPageValidator);
      validator.ValidateSite(documentationPage);
    }

    [Then(@"the validators error messages should read")]
    public void ThenTheValidatorsErrorMessagesShouldRead(string errorMessages)
    {
      var actualErrorMessages = validator.GetErrorMessages();
      errorMessages = errorMessages.Replace("{rootUrl}", TestSettings.Instance.DocsUrl);
      actualErrorMessages.ShouldBeEquivalentTo(errorMessages);
    }

    [Then(@"the validators resolution scenarios should read")]
    public void ThenTheValidatorsResolutionScenariosShouldRead(string resolutionScenarios)
    {
      var actualResolutionScenarios = validator.GetResolutionScenarios();
      resolutionScenarios = resolutionScenarios.Replace("{rootUrl}", TestSettings.Instance.DocsUrl);
      actualResolutionScenarios.ShouldBeEquivalentTo(resolutionScenarios);
    }
  }
}
