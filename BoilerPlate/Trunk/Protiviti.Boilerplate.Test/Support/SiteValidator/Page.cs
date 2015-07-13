using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public class Page
  {
    public Page(Uri url, Page referencingPage, string linkText, string linkHref, Uri baseUrl)
    {
      Url = url;
      BaseUrl = baseUrl;
      PageLinks = new List<PageLink>();
      ValidationErrors = new List<PageValidationError>();
      State = new Dictionary<string, object>();
      if (referencingPage != null)
        new PageLink(referencingPage, this, linkText, linkHref);
    }
    public Uri Url { get; private set; }
    public Uri BaseUrl { get; private set; }
    public List<PageLink> PageLinks { get; private set; }
    public bool IsValid
    {
      get
      {
        return ValidationErrors.Count == 0;
      }
    }
    public HttpStatusCode StatusCode { get; private set; }
    public string ReasonPhrase { get; private set; }

    public Exception RequestException { get; set; }
    public bool HasBeenValidated { get; private set; }
    public void MarkValidated()
    {
      HasBeenValidated = true;
    }
    public List<PageValidationError> ValidationErrors { get; private set; }

    public bool IsInternal
    {
      get
      {
        return BaseUrl.IsBaseOf(Url);
      }
    }

    public bool Found { get; private set; }
    public void MarkFound(HttpStatusCode statusCode, string reasonPhrase)
    {
      Found = true;
      StatusCode = statusCode;
      ReasonPhrase = reasonPhrase;
    }

    public void MarkMissing(HttpStatusCode statusCode, string reasonPhrase)
    {
      Found = false;
      StatusCode = statusCode;
      ReasonPhrase = reasonPhrase;
    }

    public void MarkException(Exception ex)
    {
      Found = false;
      RequestException = ex;
    }

    public Dictionary<string, object> State { get; private set;}
  }
}
