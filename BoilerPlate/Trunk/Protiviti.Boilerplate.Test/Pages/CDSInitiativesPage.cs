using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Protiviti.Boilerplate.Test.Pages
{
    public class CDSInitiativesPage
    {
        //values to enter on task details
        private static string _taskNameValue = "Find Proposals";
        private static string _firstNameValue = "Ben";
        private static string _lastNameValue = "Bloomfield";
        private static string _descriptionTextValue = "Show Me The Money";
        private static string _taskUrlValue = "http://google.com";
        private static string _invalidUrlValue = "googledotcom";
        private static string _invalidEmailValue = "testatgmail.com";
        private static string _contactNameValue = "Ben Bloomfield";
        private static string _validEmailValue = "ben.bloomfield@protiviti.com";
        
        public static bool IsAt()
        {
            const string linkText = "CDS Initiatives (Nav Demo)";
            SeleniumController.SleepWaitTime(3000);
            SeleniumController.WaitTime("h1");
            var pageTitle = SeleniumController.Instance.Driver.FindElement(By.CssSelector("h1"));
            if (pageTitle.Text == linkText)
                return true;
            else
            {
                Console.WriteLine(pageTitle.Text);
                return false;
        }
        }

        public static void SelectTab(string tabName)
        {
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));

            //Finidng the tab bar
            var selectedHomePageTab = SeleniumController.Instance.Driver.FindElements(By.XPath("/html/body/div/div/header/div/nav/div/div[2]/ul[1]/li/a"));

            //Clicking the tab
            switch (tabName)
            {
                case "DashBoard":
                    selectedHomePageTab[0].Click();
                    break;
                case "Employee":
                    selectedHomePageTab[1].Click();
                    break;
                case "CDS Initiatives":
                    selectedHomePageTab[2].Click();
                    break;
                case "Registration":
                    selectedHomePageTab[7].Click();
                    break;
                default:
                    ;
                    break;
            }
            //this item cant be found message;
        }
        //Viewing the CDS Int page
        public static void GoTo()
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Client/#/initiatives");
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
        }


        //Navigate to the sales page
        public static void ClickSalesLink()
        {
            SeleniumController.WaitTime("a[id='menu-toggle']");
           var salesLink = SeleniumController.Instance.Driver.FindElement(By.LinkText("Sales"));
            salesLink.Click();
        }

        public static void ClickLinkById(string id)
        {
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            var linkName = SeleniumController.Instance.Driver.FindElement(By.Id(id));
            linkName.Click();
        }

        //Verify the contents of the title/Sales text on the initiative page
        public static bool HasTitle()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.CssSelector("h2[class*='ng-binding']"), 30);
            var salesTitle = SeleniumController.Instance.Driver.FindElement(By.CssSelector("h2[class*='ng-binding']"));
            if (salesTitle.Text == "Sales")
                return true;
            else
                return false;
        }

        //Verify that there is a link to the first task/find proposals on the page
        public static bool HasFirstTask()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText("Find Proposals"), 30);
            var firstTask = SeleniumController.Instance.Driver.FindElement(By.LinkText("Find Proposals"));
            if (firstTask.Text == "Find Proposals")
                return true;
            else return false;

        }

        //Go to the first task/find proposals on the page
        public static void ViewFirstTask()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText("Find Proposals"), 30);
            var firstTask = SeleniumController.Instance.Driver.FindElement(By.LinkText("Find Proposals"));
            firstTask.Click();

        }

        //View the text on the task details page for the find proposals task

        public static bool HasTaskDetails()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("txtContact"), 30);
            var taskDetails = SeleniumController.Instance.Driver.FindElement(By.Id("txtContact"));
            System.Threading.Thread.Sleep(300);
            if (taskDetails.Text == "Bob Barker")
                return true;
            else return false;

        }


        //Verify that there is a link to the second task/pitch pss value on the page.
        public static bool HasSecondTask()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText("Pitch PSS Value"), 30);
            var secondTask = SeleniumController.Instance.Driver.FindElement(By.LinkText("Pitch PSS Value"));
            if (secondTask.Text == "Pitch PSS Value")
                return true;
            else return false;

        }
        // Verify the Url is correct for each initiative and task
        public static bool IsAtCorrectUrl(string url)
        {
            SeleniumController.SleepWaitTime(2000);
           bool correctURL = SeleniumController.Instance.Driver.Url.Contains(url);
            return correctURL;
        }


        //Click on an initiative link by the text of the title
        public static void ClickByLinkText(string linkText)
        {
            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText(linkText), 30);
            var salesLink = SeleniumController.Instance.Driver.FindElement(By.LinkText(linkText));
            salesLink.Click();
        }

        //Verify that the task details text is shown and is correct for the task
        public static bool HasCorrectTaskText(string taskText)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.CssSelector("h4[class*='ng-binding']"), 30);
            //var taskDetailsText = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div[1]/div/section/div/div/div[3]/div/div/div/form/div[1]/h4"));
            IWebElement taskDetailsText = SeleniumController.Instance.Driver.FindElement(By.CssSelector("h4[class*='ng-binding']"));
            //System.Threading.Thread.Sleep(300);
            if (taskDetailsText.Text == taskText)
                return true;
            else return false;
        }
    
        //Enter values into fields on a task details page

        //Enter a task name
        public static void EnterTaskName()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtTaskName"), 30);
            string taskName = _taskNameValue;
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtTaskName"));
            textBox.Clear();
            textBox.SendKeys(taskName);

        }
        //Check entered task name
        public static bool HasEnteredTaskName()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtTaskName"), 30);
            var taskName = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtTaskName")).GetAttribute("value");
            if (taskName == _taskNameValue)
                return true;
            else return false;
        }
        
        //Leave task name blank
        public static void LeaveTaskNameBlank()
        {
            SeleniumController.WaitTime("input#initiatve_txtTaskName");
            var blankTaskName = _taskNameValue;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtTaskName"), 50); 
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtTaskName"));
            textBox.Clear();
        }

        //Enter a First Name
        public static void EnterFirstName()
        {
            string firstName = _firstNameValue;
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtFirstName"));
            textBox.Clear();
            textBox.SendKeys(firstName);
        }
        //Check entered first name
        public static bool HasEnteredFirstName()
        {
            var taskName = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtFirstName")).GetAttribute("value");
            if (taskName == _firstNameValue)
                return true;
            else return false;
        }
        // Leave first name blank
        public static void LeaveFirstNameBlank()
        {
            var blankFirstName = _firstNameValue;
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtFirstName"));
            textBox.Clear();
        }
        //Enter a Last Name
        public static void EnterLastName()
        {
            string lastName = _lastNameValue;
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtLastName"));
            textBox.Clear();
            textBox.SendKeys(lastName);
        }
        //Check entered last name
        public static bool HasEnteredLastName()
        {
            var taskName = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtLastName")).GetAttribute("value");
            if (taskName == _lastNameValue)
                return true;
            else return false;
        }
        // Leave Last Name blank
        public static void LeaveLastNameBlank()
        {
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtLastName"));
            textBox.Clear();
        }
           
        //Enter a Description
        public static void EnterDescriptionText()
        {
            string descriptionText = _descriptionTextValue;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtDescription"), 30);
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtDescription"));
            textBox.Clear();
            textBox.SendKeys(descriptionText);
        }
        // Check entered description
        public static bool HasEnteredDescriptionText()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtDescription"), 30);
            var taskName = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtDescription")).GetAttribute("value");
            if (taskName == _descriptionTextValue)
                return true;
            else return false;
        }
        //Enter a Url
        public static void EnterTaskURL()
        {
            string taskURL = _taskUrlValue;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtUrl"), 30);
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtUrl"));
            textBox.Clear();
            textBox.SendKeys(taskURL);
        }
        //Check entered url
        public static bool HasEnteredTaskURL()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtUrl"), 30);
            var taskName = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtUrl")).GetAttribute("value");
            if (taskName == _taskUrlValue)
                return true;
            else return false;
        }
        //Click Save Button
        public static void ClickSaveButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiative_btnSave"), 30);
            var saveButton = SeleniumController.Instance.Driver.FindElement(By.Id("initiative_btnSave"));
            saveButton.Click();
        }
        //Verify Task Name is required
        public static bool HasTaskNameRequiredMessage()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("invalid"), 50);
            var taskNameRequiredMessage = SeleniumController.Instance.Driver.FindElement(By.ClassName("invalid"));
            if (taskNameRequiredMessage.Text == "'TaskName' is required")
                return true;
            else return false;
        }

        //Verify First Name is required
        public static bool HasFirstNameRequiredMessage()
        {
            var firstNameRequiredMessage = SeleniumController.Instance.Driver.FindElement(By.ClassName("invalid"));
            if (firstNameRequiredMessage.Text == "'FirstName' is required")
                return true;
            else return false;
        }

        //Verify Last Name is Required
        public static bool HasLastNameRequiredMessage()
        {
            var lastNameRequiredMessage = SeleniumController.Instance.Driver.FindElement(By.ClassName("invalid"));
            if (lastNameRequiredMessage.Text == "'LastName' is required")
                return true;
            else return false;
        }

       //Select contact
        public static void SelectContactName()
        {
            SeleniumController.SleepWaitTime(30);
            var select = SeleniumController.Instance.Driver.FindElement(By.Id("initiative_ddlContact")).FindElement(By.CssSelector("option[value='3']"));
            select.Click();
          
        }
        // verify selected contact is correct

        public static bool HasSelectedContact()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.CssSelector("option[value='3']"), 30);
            var selectedContact = SeleniumController.Instance.Driver.FindElement(By.CssSelector("option[value='3']")).GetAttribute("value");
                
            if (selectedContact == "3")
                return true;
            else return false;
        }

        //Enter valid email
        public static void EnterValidEmail()
        {
            SeleniumController.WaitTime("input#initiatve_txtEmail");
            string validEmail = _validEmailValue;
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtEmail"));
            textBox.Clear();
            textBox.SendKeys(validEmail);
        }

        //Enter invalid email
        public static void EnterInvalidEmail()
        {
            SeleniumController.WaitTime("input#initiatve_txtEmail");
            string invalidEmail = _invalidEmailValue;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtEmail"), 50); 
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtEmail"));
            textBox.Clear();
            textBox.SendKeys(invalidEmail);
        }
        // Has entered email

        public static bool HasEnteredEmail()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtEmail"), 30);
            var enteredEmail = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtEmail")).GetAttribute("value");
            if (enteredEmail == _validEmailValue)
                return true;
            else return false;
        }

        // has invalid email message
        public static bool HasInvalidEmailMessage()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.ClassName("invalid"), 50); 
            var invalidEmailMessage = SeleniumController.Instance.Driver.FindElement(By.ClassName("invalid"));
            if (invalidEmailMessage.Text == "The Email 'testatgmail.com' is not a valid email address")
                return true;
            else return false;
        }

        //Enter invalid URL
        public static void EnterInvalidURL()
        {
            SeleniumController.WaitTime("input#initiatve_txtUrl");
            string invalidURL = _invalidUrlValue;
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtUrl"), 50); 
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtUrl"));
            textBox.Clear();
            textBox.SendKeys(invalidURL);
            SeleniumController.SleepWaitTime(2000);
        }

        // Has invalid url message
        public static bool HasInvalidURLMessage()
        {
            SeleniumController.WaitTime("span.invalid");
            var invalidURLMessage = SeleniumController.Instance.Driver.FindElement(By.ClassName("invalid"));
            if (invalidURLMessage.Text == "The Url 'googledotcom' is not a valid url")
                return true;
            else return false;
        }

        //Select Start Date
        public static void ClickCalendarButton()
        {
            var calendarButton = SeleniumController.Instance.Driver.FindElement(By.ClassName("k - select"));
            calendarButton.Click();
        }
        public static void SelectDateFromCalendar()
        {
            DateTime today = DateTime.Now;
            DateTime newDate = today.AddDays(3);

            var startDate = newDate.ToShortDateString();

            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtStartDate"), 30);
            var textBox = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtStartDate"));
            textBox.Clear();
            textBox.SendKeys(startDate);
            

        }

       // Verify correct start date
        public static bool HasCorrectStartDate()
        {
            DateTime today = DateTime.Now;
            DateTime newDate = today.AddDays(3);

            var startDate = newDate.ToShortDateString();
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("initiatve_txtStartDate"), 30);
            var enteredStartDate = SeleniumController.Instance.Driver.FindElement(By.Id("initiatve_txtStartDate")).GetAttribute("value");
            if (enteredStartDate == startDate)
                return true;
            else return false;
        }
       
    }

}

          
