using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public class PageLink
  {
    public PageLink(Page referencingPage, Page referencedPage, string linkText, string linkHref)
    {
      ReferencingPage = referencingPage;
      ReferencedPage = referencedPage;
      ReferencingPage.PageLinks.Add(this);
      ReferencedPage.PageLinks.Add(this);
      LinkText = linkText;
      LinkHref = linkHref;
    }
    public Page ReferencingPage { get; private set; }
    public Page ReferencedPage { get; private set; }
    public string LinkText { get; private set; }
    public string LinkHref { get; private set; }
  }
}
