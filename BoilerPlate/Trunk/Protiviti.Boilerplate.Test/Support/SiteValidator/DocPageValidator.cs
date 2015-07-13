using ScrapySharp.Network;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public class DocPageValidator : IPageValidator, IBadLinkResolver
  {
    public void ValidatePage(Page page, WebPage webPage)
    {
      ValidateTag(page, webPage, new Regex(DocPageValidatorResources.OwnerRegex),
        DocPageValidatorResources.OwnerTagName, 
        DocPageValidatorResources.OwnerTagSelector, 
        DocPageValidatorResources.MultipleOwnerTagsErrorType, 
        DocPageValidatorResources.MultipleOwnerTagsErrorMessage,
        DocPageValidatorResources.ImproperOwnerTagErrorType, 
        DocPageValidatorResources.ImproperOwnerTagErrorMessage);
      ValidateTag(page, webPage, new Regex(DocPageValidatorResources.ReviewerRegex), 
        DocPageValidatorResources.ReviewerTagName, 
        DocPageValidatorResources.ReviewerTagSelector,
        DocPageValidatorResources.MultipleReviewerTagsErrorType, 
        DocPageValidatorResources.MultipleReviewerTagsErrorMessage,
        DocPageValidatorResources.ImproperReviewerTagErrorType, 
        DocPageValidatorResources.ImproperReviewerTagErrorMessage);
      ValidateUpdatedOrReviewed(page, webPage, DocPageValidatorResources.UpdatedTagName);
      ValidateUpdatedOrReviewed(page, webPage, DocPageValidatorResources.ReviewedTagName);
      ValidateReviewedAfterUpdated(page);
      ValidateReviewedAfterOldestAllowedDate(page);
      ValidateTitle(page, webPage);
    }

    private static void ValidateReviewedAfterUpdated(Page page)
    {
      if(page.State.Keys.Contains(DocPageValidatorResources.PageStateKeyUpdatedDate) 
        && page.State.Keys.Contains(DocPageValidatorResources.PageStateKeyReviewedDate))
      {
        var updatedDate = (DateTime)page.State[DocPageValidatorResources.PageStateKeyUpdatedDate];
        var reviewedDate = (DateTime)page.State[DocPageValidatorResources.PageStateKeyReviewedDate];
        if(updatedDate > reviewedDate)
        {
          var reviewer = DocPageValidatorResources.UnassignedReviewerName;
          if (TestSettings.Instance.DefaultDocumentationReviewer != null)
            reviewer = TestSettings.Instance.DefaultDocumentationReviewer.Replace(" ", "");
          if(page.State.Keys.Contains(DocPageValidatorResources.PageStateKeyReviewer))
          {
            reviewer = page.State[DocPageValidatorResources.PageStateKeyReviewer].ToString().Replace(" ", "");
          }

          var resolutionScenario = String.Format(DocPageValidatorResources.UnreviewedChangeResolutionScenario,
            TestSettings.Instance.CurrentSprint,
            reviewer,
            TestSettings.Instance.ErrorResolutionPriorities[DocPageValidatorResources.UnreviewedChangeErrorType],
            page.Url.AbsoluteUri);

          page.ValidationErrors.Add(new PageValidationError(
            DocPageValidatorResources.UnreviewedChangeErrorType,
            DocPageValidatorResources.UnreviewedChangeErrorMessage,
            resolutionScenario
            ));
        }
      }
    }
    private static void ValidateReviewedAfterOldestAllowedDate(Page page)
    {
      if (page.State.Keys.Contains(DocPageValidatorResources.PageStateKeyReviewedDate))
      {
        var reviewedDate = (DateTime)page.State[DocPageValidatorResources.PageStateKeyReviewedDate];
        var oldestReviewedDate = DateTime.Now.AddMonths(-TestSettings.Instance.ValidReviewAgeInMonths);
        if (oldestReviewedDate > reviewedDate)
        {
          var reviewer = DocPageValidatorResources.UnassignedReviewerName;
          if (TestSettings.Instance.DefaultDocumentationReviewer != null)
            reviewer = TestSettings.Instance.DefaultDocumentationReviewer.Replace(" ", "");
          if (page.State.Keys.Contains(DocPageValidatorResources.PageStateKeyReviewer))
          {
            reviewer = page.State[DocPageValidatorResources.PageStateKeyReviewer].ToString().Replace(" ", "");
          }

          var resolutionScenario = String.Format(DocPageValidatorResources.AgedReviewResolutionScenario,
            TestSettings.Instance.CurrentSprint,
            reviewer,
            TestSettings.Instance.ErrorResolutionPriorities[DocPageValidatorResources.AgedReviewErrorType],
            page.Url.AbsoluteUri,
            TestSettings.Instance.ValidReviewAgeInMonths);

          page.ValidationErrors.Add(new PageValidationError(
            DocPageValidatorResources.AgedReviewErrorType,
            DocPageValidatorResources.AgedReviewErrorMessage,
            resolutionScenario.ToString()
            ));
        }
      }
    }
    private static void ValidateUpdatedOrReviewed(Page page, WebPage webPage, string tagName)
    {
      string upperCaseTagName = tagName.Substring(0, 1).ToUpper() + tagName.Substring(1, tagName.Length - 1);
      var cssSelector = String.Format(DocPageValidatorResources.TagSelector,tagName);
      var missingErrorType = String.Format(DocPageValidatorResources.MissingTagErrorType, upperCaseTagName);
      var missingErrorMessage = String.Format(DocPageValidatorResources.MissingTagErrorMessage, tagName, upperCaseTagName);
      var multipleErrorType = String.Format(DocPageValidatorResources.MultipleTagsErrorType, upperCaseTagName);
      var multipleErrorMessage = String.Format(DocPageValidatorResources.MultipleTagsErrorMessage, tagName);
      var matcherString = String.Format(DocPageValidatorResources.TagMatcher, upperCaseTagName);
      var invalidDateErrorType = String.Format(DocPageValidatorResources.InvalidDateErrorType, upperCaseTagName);
      var invalidDateErrorMessage = String.Format(DocPageValidatorResources.InvalidDateErrorMesssage, tagName);
      var futureDateErrorType = String.Format(DocPageValidatorResources.FutureDateErrorType, upperCaseTagName);
      var futureDateErrorMessage = String.Format(DocPageValidatorResources.FutureDateErrorMessage, tagName);
      var invalidErrorType = String.Format(DocPageValidatorResources.InvalidTagErrorType, upperCaseTagName);
      var invalidErrorMessage = String.Format(DocPageValidatorResources.InvalidTagErrorMessage, tagName, upperCaseTagName);
      var updated = webPage.Html.CssSelect(cssSelector).ToList();
      if (updated.Count() == 0)
      {
        page.ValidationErrors.Add(new PageValidationError(
          missingErrorType,
          missingErrorMessage,
          ""
          ));
      }
      if (updated.Count() > 1)
      {
        page.ValidationErrors.Add(new PageValidationError(
          multipleErrorType,
          multipleErrorMessage,
          ""
          ));
      }
      if (updated.Count() == 1)
      {
        var reviewText = updated[0].InnerText;
        var matcher = new Regex(matcherString);
        var match = matcher.Match(reviewText);
        if (match.Success)
        {
          var dateString = match.Groups[1].Value;
          DateTime updatedDate = new DateTime();
          if (!DateTime.TryParse(dateString, out updatedDate))
          {
            page.ValidationErrors.Add(new PageValidationError(
              invalidDateErrorType,
              invalidDateErrorMessage,
              ""
              ));
          }
          else
          {
            if (updatedDate.AddDays(1) > DateTime.Now)
            {
              page.ValidationErrors.Add(new PageValidationError(
                futureDateErrorType,
                futureDateErrorMessage,
                ""
                ));
            }
            else
            {
              if(tagName == DocPageValidatorResources.UpdatedTagName)
              {
                page.State[DocPageValidatorResources.PageStateKeyUpdatedDate] = updatedDate;
                page.State[DocPageValidatorResources.PageStateKeyUpdatedPerson] = match.Groups[2].Value;
              }
              else
              {
                page.State[DocPageValidatorResources.PageStateKeyReviewedDate] = updatedDate;
                page.State[DocPageValidatorResources.PageStateKeyReviewedPerson] = match.Groups[2].Value;
              }
            }
          }
        }
        else
        {
          page.ValidationErrors.Add(new PageValidationError(
            invalidErrorType,
            invalidErrorMessage,
            ""
            ));
        }
      }
    }
    private static void ValidateTitle(Page page, WebPage webPage)
    {
      var title = webPage.Html.CssSelect("h1").ToList();
      if (title.Count() == 0)
      {
        page.ValidationErrors.Add(new PageValidationError(
          "DocMissingTitle",
          "The page does not have an h1 at the top to serve as a title.",
          ""
          ));
      }
      if (title.Count() > 1)
      {
        page.ValidationErrors.Add(new PageValidationError(
          "DocMultipleTitles",
          "The page has multiple 'h1' tags.  Please remove all but one and place it at the top of the page.",
          ""
          ));
      }
    }

    private static void ValidateTag(Page page, WebPage webPage, 
      Regex valueExtractor, string tagName, string selector, 
      string multipleErrorType, string multipleErrorMessage, 
      string emptyErrorType, string emptyErrorMessage)
    {
      var tag = webPage.Html.CssSelect(selector).ToList();
      if (tag.Count() > 1)
      {
        page.ValidationErrors.Add(new PageValidationError(
          multipleErrorType,
          multipleErrorMessage,
          ""
          ));
      }
      if (tag.Count() == 1)
      {
        var tagText = tag[0].InnerText;
        var tagValue = valueExtractor.Match(tagText);
        if (tagValue.Groups.Count < 2 || tagValue.Groups[1].Value == "")
        {
          page.ValidationErrors.Add(new PageValidationError(
            emptyErrorType,
            emptyErrorMessage,
            ""
            ));
        }
        else
        {
          page.State.Add(tagName.ToUpper(), tagValue.Groups[1].ToString().Replace(" ", ""));
        }
      }
    }
    public void SetResolutionScenario(PageLink pageLink, PageValidationError pageValidationError)
    {
      var resolutionOwner = TestSettings.Instance.DefaultDocumentationOwner;
      if (pageLink.ReferencingPage.State.Keys.Contains(DocPageValidatorResources.PageStateKeyOwner))
        resolutionOwner = pageLink.ReferencingPage.State[DocPageValidatorResources.PageStateKeyOwner].ToString();
      var sprint = TestSettings.Instance.CurrentSprint;
      var priority = TestSettings.Instance.ErrorResolutionPriorities[pageValidationError.ValidationType];
      var resolutionScenario = String.Format(DocPageValidatorResources.InvalidPageLinkResolutionScenario,
        sprint,
        resolutionOwner,
        priority,
        pageLink.LinkText,
        pageLink.ReferencingPage.Url.AbsoluteUri);
      pageValidationError.ResolutionScenario = resolutionScenario;
    }
  }
}
