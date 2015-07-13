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
    public class NestedNavigationWithUi_RouterStepsSimpleSales1
    {
        [Given(@"I am viewing the""CDS Initiatives Page")]
        public static void GoTo()
        {
            CDSInitiativesPage.GoTo();
        }

        [When(@"I click the Sales link")]
        public static void ClickSalesLink()
        {
            CDSInitiativesPage.ClickSalesLink();
           
        }

        [Then(@"I should see the Sales Title on the page")]
        public static void HasTitle()
        {
      
            Assert.IsTrue(Pages.CDSInitiativesPage.HasTitle(), "No title Found");
       
        }
       
        [Then(@"I should see ""(.*)"" in the URL")]
        public static void IsAtCorrectUrl(string p0)
        {
        //    SeleniumController.SleepWaitTime(3000);
            Assert.IsTrue(Pages.CDSInitiativesPage.IsAtCorrectUrl(p0));
          //  SeleniumController.SleepWaitTime(3000);
        }


        [Then(@"I should see the Find Proposals Task")]
        public static void HasFirstTask()
        {
           Assert.IsTrue(CDSInitiativesPage.HasFirstTask());
        }

        [Then(@"I should see the Pitch PSS Value Task")]
        public static void HasSecondTask()
        {
            Assert.IsTrue(Pages.CDSInitiativesPage.HasSecondTask());
        }

    }
}