using Protiviti.Boilerplate.Test.Pages;
using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Support;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class NestedNavigationWithUiNavigatetoCDSIntUrlCheck
    {
        [When(@"I click ""(.*)"" link")]
public static void WhenIClickLink(string p0)
{
    SeleniumController.WaitTime("div.sidebar-wrapper");
    CDSInitiativesPage.ClickByLinkText(p0);
    //SeleniumController.SleepWaitTime(2000);
}

   
    }
}
