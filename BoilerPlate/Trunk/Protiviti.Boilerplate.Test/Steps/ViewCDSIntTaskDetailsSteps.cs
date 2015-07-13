using System;
using TechTalk.SpecFlow;
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
    public class ViewCDSIntTaskDetailsSteps
    {
        [Given(@"I am viewing the CDS Initiatives page")]
        public static void GoTo()
        {
            CDSInitiativesPage.GoTo();
        }

        [Given(@"I click the Sales link")]
        public static void ClickSalesLink()
        {
            CDSInitiativesPage.ClickSalesLink();

        }

        [When(@"I click the first task name I see")]
        public static void ViewFirstTask()
        {
            var firstTask = SeleniumController.Instance.Driver.FindElement(By.LinkText("Find Proposals"));
            firstTask.Click();
         

        }
        [Then(@"I should see the task details text")]
        public void HasTaskDetails()
        {
           
            Assert.IsTrue(Pages.CDSInitiativesPage.HasTaskDetails(), "No Text Found");
        }
    }
}
