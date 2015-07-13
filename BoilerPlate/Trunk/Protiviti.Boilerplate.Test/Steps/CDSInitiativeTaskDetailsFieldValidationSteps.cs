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
    public class CDSInitiativeTaskDetailsFieldValidationSteps
    {
        [Given(@"I am viewing the first task for the first CDS Initiative")]
public void GivenIAmViewingTheFirstTaskForTheFirstCDSInitiative()
{
    SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/initiatives/1/1");
    SeleniumController.CheckUrlOfPage("http://localhost/Protiviti.Boilerplate.Client/#/initiatives/1/1");
}

        [When(@"I enter a task name")]
public void WhenIEnterATaskName()
{
    System.Threading.Thread.Sleep(300);
            Pages.CDSInitiativesPage.EnterTaskName();
}

        [When(@"I select an initiative contact")]
public void WhenISelectAnInitiativeContact()
{
    Pages.CDSInitiativesPage.SelectContactName();
}

        [When(@"I enter a valid email")]
public void WhenIEnterAValidEmail()
{
    Pages.CDSInitiativesPage.EnterValidEmail();
}

        [When(@"I select a start date")]
public void WhenISelectAStartDate()
{
    Pages.CDSInitiativesPage.SelectDateFromCalendar();
}

        [When(@"I enter a description")]
public void WhenIEnterADescription()
{
    Pages.CDSInitiativesPage.EnterDescriptionText();
}

        [When(@"I enter a valid URL")]
public void WhenIEnterAValidURL()
{
    Pages.CDSInitiativesPage.EnterTaskURL();
}

        [When(@"I click Save")]
public void WhenIClickSave()
{
    Pages.CDSInitiativesPage.ClickSaveButton();
    System.Threading.Thread.Sleep(4000);
}

        [When(@"I do not enter a task name")]
public void WhenIDoNotEnterATaskName()
{
    Pages.CDSInitiativesPage.LeaveTaskNameBlank();
}

        [When(@"I enter an invalid URL")]
public void WhenIEnterAnInvalidURL()
{
    Pages.CDSInitiativesPage.EnterInvalidURL();
}

        [When(@"I enter an invalid email")]
public void WhenIEnterAnInvalidEmail()
{
    Pages.CDSInitiativesPage.EnterInvalidEmail();
}

        [Then(@"I should see the new task name")]
public void ThenIShouldSeeTheNewTaskName()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasEnteredTaskName());
}

        [Then(@"I should see my selected initiative contact")]
public void ThenIShouldSeeMySelectedInitiativeContact()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasSelectedContact());
}

        [Then(@"I should see my entered email")]
public void ThenIShouldSeeMyEnteredEmail()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasEnteredEmail());
}

        [Then(@"I should see my selected start date")]
public void ThenIShouldSeeMySelectedStartDate()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasCorrectStartDate());
}

        [Then(@"I should see my entered description")]
public void ThenIShouldSeeMyEnteredDescription()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasEnteredDescriptionText());
}

        [Then(@"I should see my entered URL")]
public void ThenIShouldSeeMyEnteredURL()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasEnteredTaskURL());
}

        [Then(@"I should see the task name required message")]
public void ThenIShouldSeeTheTaskNameRequiredMessage()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasTaskNameRequiredMessage());
    Pages.CDSInitiativesPage.EnterTaskName();
    Pages.CDSInitiativesPage.ClickSaveButton();
}

        [Then(@"I should see the  URL is not valid message")]
public void ThenIShouldSeeTheURLIsNotValidMessage()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasInvalidURLMessage());
}

        [Then(@"I should see the email is not valid message")]
public void ThenIShouldSeeTheEmailIsNotValidMessage()
{
    Assert.IsTrue(Pages.CDSInitiativesPage.HasInvalidEmailMessage());
}
    }
}
