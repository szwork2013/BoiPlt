using System;
using TechTalk.SpecFlow;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class NestedNavigationWithUITaskTextCheck
    {
        [Then(@"I should see the ""(.*)"" for that initiative")]
        public static void HasCorrectTaskText(string p0)
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasCorrectTaskText(p0), "no text found");
}
    }
}
