using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public interface IBadLinkResolver
  {
    void SetResolutionScenario(PageLink pageLink, PageValidationError pageValidationError);
  }
}
