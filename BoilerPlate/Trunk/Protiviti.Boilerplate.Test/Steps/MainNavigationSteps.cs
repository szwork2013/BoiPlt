using System;
using TechTalk.SpecFlow;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class MainNavigationSteps
    {
        [Then(@"the CDS Initiatives page should load")]
        public void ThenTheCDSInitiativesPageShouldLoad()
        {
            Assert.IsTrue(Pages.CDSInitiativesPage.IsAt());
        }
    }
}
