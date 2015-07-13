using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Protiviti.Boilerplate.Test.Pages
{
    public  class EmployeePage
    {
        public static bool IsAt()
        {
            //Assert.AreEqual(true, WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText("Employees"), 30));
            var registrationLink = SeleniumController.Instance.Driver.FindElement(By.LinkText("Employees"));

            if (registrationLink.Text == "Employees")
                return true;
            else
                return false;
        }
        public static bool CheckInputFields()
        {
             Assert.AreEqual(true,WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div/div/div[2]/table/thead/tr/th"), 30));
                var tableHeader = SeleniumController.Instance.Driver.FindElements(By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div/div/div[2]/table/thead/tr/th"));
                if ((tableHeader[1].Text == "First Name") && (tableHeader[2].Text == "Last Name") && (tableHeader[3].Text == "Division") && (tableHeader[4].Text == "Designation") && (tableHeader[5].Text == "Address"))
                    return true;
                else
                    return false;
        }
        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/employees");
        }
        public static void ClickRegisterLink()
        {
            var registrationLink = SeleniumController.Instance.Driver.FindElement(By.LinkText("Register as a new user"));
            registrationLink.Click();
        }
    }
}
