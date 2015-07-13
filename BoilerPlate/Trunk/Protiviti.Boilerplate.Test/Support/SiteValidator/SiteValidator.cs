using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Diagnostics;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public class SiteValidator
  {
    public Uri RootUrl { private set; get; }
    private bool rootPageIsMissing = false;
    private ScrapingBrowser browser = new ScrapingBrowser();
    private List<Page> pages = new List<Page>();
    private List<IPageValidator> pageValidators = new List<IPageValidator>();
    private IBadLinkResolver badLinkResolver { get; set; }
    public void ValidateSite(Uri url)
    {
      RootUrl = url;
      var rootPage = new Page(url, null, null, null, url);
      pages.Add(rootPage);
      var unvalidated = 1;
      while(unvalidated > 0)
      {
        var unvalidatedPages = pages.Where(x => x.HasBeenValidated == false).ToArray();
        foreach(var page in unvalidatedPages)
        {
          ValidatePage(page);
        }
        unvalidated = pages.Where(x => x. HasBeenValidated == false).Count();
      }
      SetPageLinkValidationErrors();
    }
    public void ValidatePage(Page page)
    {
      ValidatePageExists(page);
      if (page.Found == false && page.Url == RootUrl)
        rootPageIsMissing = true;
      if(page.Found && page.IsInternal)
          LoadChildPages(page);
      page.MarkValidated();
    }

    private void ValidatePageExists(Page page)
    {
      using (var client = new HttpClient())
      {
        try
        {
          ValidatePageExistViaHeadRequest(page, client);
          if(!page.Found)
          {
            ValidatePageExistViaGetRequest(page, client);
          }
        }
        catch (Exception ex)
        {
          page.MarkException(ex);
        }
      }
    }

    private void ValidatePageExistViaHeadRequest(Page page, HttpClient client)
    {
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, page.Url);
      var response = client.SendAsync(requestMessage).Result;
      if (response.IsSuccessStatusCode)
      {
        page.MarkFound(response.StatusCode, response.ReasonPhrase);
      }
      else
      {
        page.MarkMissing(response.StatusCode, response.ReasonPhrase);
      }
    }

    private void ValidatePageExistViaGetRequest(Page page, HttpClient client)
    {
      var requestMessage = new HttpRequestMessage(HttpMethod.Head, page.Url);
      var response = client.SendAsync(requestMessage).Result;
      if (response.IsSuccessStatusCode)
      {
        page.MarkFound(response.StatusCode, response.ReasonPhrase);
      }
      else
      {
        page.MarkMissing(response.StatusCode, response.ReasonPhrase);
      }
    }

    private void SetPageLinkValidationErrors()
    {
      foreach (var page in pages)
      {
        foreach (var pageLink in page.PageLinks)
        {
          if (!pageLink.ReferencedPage.Found)
          {
            if (pageLink.ReferencedPage.RequestException != null)
            {
              var pageValidationError = new PageValidationError(
                SiteValidatorResources.LinkRequestExceptionErrorType,
                String.Format(SiteValidatorResources.LinkRequestExceptionErrorMessage, pageLink.LinkText, pageLink.LinkHref, pageLink.ReferencedPage.RequestException.Message),
                "");
              page.ValidationErrors.Add(pageValidationError);
              if (badLinkResolver != null)
                badLinkResolver.SetResolutionScenario(pageLink, pageValidationError);
            }
            else
            {
              var pageValidationError = new PageValidationError(
                SiteValidatorResources.LinkRequestNonSuccessStatusCodeErrorType,
                String.Format(SiteValidatorResources.LinkRequestNonSuccessStatusCodeErrorMessage, pageLink.LinkText, pageLink.LinkHref, pageLink.ReferencedPage.StatusCode),
                ""
                );
              page.ValidationErrors.Add(pageValidationError);
              if (badLinkResolver != null)
                badLinkResolver.SetResolutionScenario(pageLink, pageValidationError);
            }
          }
        }
      }
    }

    public void LoadChildPages(Page page)
    {
      var response = browser.NavigateToPage(page.Url);
      pageValidators.ForEach(x => x.ValidatePage(page, response));
      var linkNodes = response.Html.CssSelect("a");
      foreach (var linkNode in linkNodes)
      {
        Uri linkUri = null;
        var linkHref = linkNode.Attributes["href"].Value;
        if (linkHref.StartsWith("/"))
          linkUri = new Uri(RootUrl, linkHref);
        else if (linkHref.StartsWith("http"))
          linkUri = new Uri(linkHref);
        else
          linkUri = new Uri(page.Url, linkHref);
        var linkText = linkNode.InnerText;
        var referencedPage = pages.Where(x => x.Url.AbsoluteUri == linkUri.AbsoluteUri).FirstOrDefault();
        if (referencedPage != null)
        {
          var pageReference = referencedPage.PageLinks.Where(x => x.LinkText == linkText && x.ReferencingPage.Url.AbsoluteUri == page.Url.AbsoluteUri).SingleOrDefault();
          if (pageReference == null)
          {
            var pageLink = new PageLink(page, referencedPage, linkText, linkHref);
          }
        }
        else
        {
          referencedPage = new Page(linkUri, page, linkText, linkHref, RootUrl);
          pages.Add(referencedPage);
        }

      }
    }

    public string GetErrorMessages()
    {
      var first = true;
      StringBuilder sb = new StringBuilder();
      if (rootPageIsMissing)
      {
        sb.Append(String.Format(SiteValidatorResources.RootPageNotFoundErrorMessage, RootUrl.AbsoluteUri));
      }
      else
      {
        foreach (var page in pages.Where(x => !x.IsValid && x.Found).OrderBy(x => x.Url.AbsoluteUri))
        {
          if (first)
          {
            sb.AppendLine(SiteValidatorResources.ErrorMessagesOpeningLine);
            first = false;
          }
          sb.AppendLine(String.Format(SiteValidatorResources.ErrorMessagesPageLine, page.Url.AbsoluteUri));
          foreach (var validationError in page.ValidationErrors)
          {
            sb.AppendLine(String.Format(SiteValidatorResources.ErrorMessagesPageErrorLine, validationError.ValidationType, validationError.Message));
          }
        }
      }
      return sb.ToString();
    }
    public string GetLogs()
    {
      StringBuilder sb = new StringBuilder("The following targets were valid:\n");
      foreach (var target in pages.Where(x => x.IsValid).OrderBy(x => x.Url.ToString()))
      {
        sb.AppendLine("Url: '" + target.Url + "'");
      }
      return sb.ToString();
    }

    internal void RegisterPageValidator(IPageValidator pageValidator)
    {
      this.pageValidators.Add(pageValidator);
    }
    internal void RegisterBadLinkResolver(IBadLinkResolver badLinkResolver)
    {
      this.badLinkResolver = badLinkResolver;
    }

    internal object GetResolutionScenarios()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("The following are recommended resolution scenarios:");
      foreach (var page in pages.Where(x => !x.IsValid && x.Found).OrderBy(x => x.Url.AbsoluteUri))
      {
        foreach (var validationError in page.ValidationErrors)
        {
          sb.AppendLine(validationError.ResolutionScenario);
        }
      }
      return sb.ToString();
    }
  }
}
