using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Linq.Expressions;
using Protiviti.Boilerplate.Test.Support;
using System.Net.Http;
using Protiviti.Boilerplate.Test.Support.SiteValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class ResearchAutomationTestingTopicsSteps
    {
        [Given(@"I have the time")]
        public void GivenIHaveTheTime()
        {
            return;
        }

        [Given(@"I hav ethe time")]
        public void GivenIHavEtheTime()
        {
            return;
        }

        [Then(@"I will study performance testing")]
        public void ThenIWillStudyPerformanceTesting()
        {
            //bool found = false;
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Docs/Architecture/PerformanceTesting/Overview");
            var title = SeleniumController.Instance.Driver.FindElements(By.TagName("h1"))[0];
            Assert.IsTrue(title.Text == "Performance Testing");  
        }



        [Then(@"I will study Implicit and explicit waits")]
        public void ThenIWillStudyImplicitAndExplicitWaits()
        {
            return;
        }

        [Then(@"Try to implement them or discuss them with the rest of the team\.")]
        public void ThenTryToImplementThemOrDiscussThemWithTheRestOfTheTeam_()
        {
            //bool found = false;
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Docs/Development/Setup/SupportAndUtilities");
            Assert.IsTrue(SeleniumController.Instance.Driver.FindElements(By.TagName("h1"))[0].Text == "Support and Utilities"  );
        }
    }
}
