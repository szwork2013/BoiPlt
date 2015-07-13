using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Support
{
  [Binding]
  public static class SeleniumSupport
  {
    private static bool ReuseWebSession
    {
      get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
    }

    [AfterTestRun()]
    public static void AfterWebScenario()
    {
      if (!ReuseWebSession)
        SeleniumController.Instance.Stop();
    }

    //[BeforeFeature("web")]
    //public static void BeforeWebFeature()
    //{
    //  SeleniumController.Instance.Start();
    //}

    //[BeforeScenario("web")]
    //public static void BeforeWebScenario()
    //{
    //  SeleniumController.Instance.Start();
    //}

    //[AfterScenario("web")]
    //public static void AfterWebScenario()
    //{
    //  if (!ReuseWebSession)
    //    SeleniumController.Instance.Stop();
    //}

    //[AfterFeature]
    //[AfterTestRun]
    //public static void AfterWebFeature()
    //{
    //  SeleniumController.Instance.Stop();
    //}
  }
}
