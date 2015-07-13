using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support.SiteValidator
{
  public class PageValidationError
  {
    public PageValidationError(string validationType, string message, string resolutionScenario)
    {
      ValidationType = validationType;
      Message = message;
      ResolutionScenario = resolutionScenario;
    }
    public string ValidationType { get; set; }
    public string Message { get; set; }
    public string ResolutionScenario { get; set; }
  }
}
