using System;
using TechTalk.SpecFlow;
using System;
using System.Threading;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Protiviti.Boilerplate.Test.Support;
using Protiviti.Boilerplate.Test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class EmployeeTabTestSteps
    {
        [Given(@"I am at the application ""([^""]*)"" page")]
        public void GivenIAmAtTheApplicationHomePage(string pageName)
        {
            PageNavigator.NavigatePage(pageName);
            

        }
        [When(@"I press the ""(.*)"" tab")]
        public void WhenIPressTheTab(string tabName)
        {
            Pages.DashboardPage.SelectTab(tabName);
               
        }
        [Then(@"the employee page should load")]
        public void ThenTheEmployeePageShouldLoad()
        {
            
            Assert.IsTrue(Pages.EmployeePage.IsAt(), "Not at the Employee Page");
        }

        [Then(@"username, password, login button and reset fields should be present")]
        public void ThenUsernamePasswordLoginButtonAndResetFieldsShouldBePresent()
        {
            SeleniumController.SleepWaitTime(2000);
            Assert.IsTrue(Pages.EmployeePage.CheckInputFields(), "All the fields are displayed");
            
        }
    }
}
