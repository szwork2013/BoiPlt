using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public interface IPageValidator
  {
    void ValidatePage(Page page, WebPage webPage);
  }
}
