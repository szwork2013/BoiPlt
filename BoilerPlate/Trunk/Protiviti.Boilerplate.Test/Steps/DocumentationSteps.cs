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

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class DocumentationSteps
    {
        [Given(@"I am a (.*)")]
        public void GivenIAmADeveloper(string userType)
        {
            return;
        }

        [When(@"I view the ""(.*)"" markdown file")]
        public void WhenIViewTheMarkdownFile(string filePath)
        {
            SeleniumController.Instance.Driver.Navigate().GoToUrl("http://localhost/Protiviti.Boilerplate.Docs/" + filePath);
        }

        [When(@"I click the ""(.*)"" link")]
        public void WhenIClickTheLink(string linkText)
        {
            SeleniumController.SleepWaitTime(1500);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.LinkText(linkText), 30);
            SeleniumController.Instance.Driver.FindElement(By.LinkText(linkText)).Click();
        }

        private IWebElement GetSection(string sectionTitle)
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.TagName("h2"), 30);
            IWebElement found = null;
            var subHeadings = SeleniumController.Instance.Driver.FindElements(By.TagName("h2"));
            foreach (var subHeading in subHeadings)
            {
                if (subHeading.Text == sectionTitle)
                    found = subHeading;
            }
            return found;
        }

        [When(@"I click the ""([^""]+)"" link in the ""([^""]+)"" section")]
        public void WhenIClickTheLink(string linkText, string sectionTitle)
        {
            IWebElement found = null;
            var inSection = false;
            var elements = SeleniumController.Instance.Driver.FindElements(By.CssSelector("div.body-content > *"));
            foreach (var element in elements)
            {
                if (found == null)
                {

                    if (element.TagName.ToLower() == "h2" && element.Text == sectionTitle && inSection == false)
                        inSection = true;
                    else if (element.TagName.ToLower() == "h2" && inSection == true)
                        inSection = false;

                    if (inSection)
                    {
                        if (element.TagName.ToLower() == "a" && element.Text == linkText)
                        {
                            found = element;
                        }
                        else
                        {
                            var currentTimeout = SeleniumController.DefaultTimeout;
                            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(1));
                            var links = element.FindElements(By.CssSelector("a"));
                            foreach (var link in links)
                            {
                                if (link.Text == linkText)
                                    found = link;
                            };
                            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(SeleniumController.DefaultTimeout);
                        }
                    }
                }
            }
            if (found != null)
                found.Click();
            else
                throw new Exception("Could not find a link with text '" + linkText + "' in the section titled '" + sectionTitle + "'");
        }

        [Then(@"the ""(.*)"" section should include a list item with the text ""(.*)""")]
        public void ThenTheSectionShouldIncludeAListItemWithTheTextLINKTEXTSECTIONTITLE(string sectionTitle, string listItemText)
        {
            IWebElement found = null;
            listItemText = listItemText.Replace("''", "\"");
            var inSection = false;
            var elements = SeleniumController.Instance.Driver.FindElements(By.CssSelector("div.body-content > *"));
            foreach (var element in elements)
            {
                if (found == null)
                {
                    if (element.TagName.ToLower() == "h2" && element.Text == sectionTitle && inSection == false)
                        inSection = true;
                    else if (element.TagName.ToLower() == "h2" && inSection == true)
                        inSection = false;

                    if (inSection)
                    {
                        if (element.TagName.ToLower() == "li" && element.Text == listItemText)
                        {
                            found = element;
                        }
                        else
                        {
                            var currentTimeout = SeleniumController.DefaultTimeout;
                            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(1));
                            var links = element.FindElements(By.CssSelector("li"));
                            foreach (var link in links)
                            {
                                if (link.Text == listItemText)
                                    found = link;
                            };
                            SeleniumController.Instance.Driver.Manage().Timeouts().ImplicitlyWait(SeleniumController.DefaultTimeout);
                        }
                    }
                }
            }
            if (found == null)
                throw new Exception("Could not find a list item with text '" + listItemText + "' in the section titled '" + sectionTitle + "'");
        }

        [Then(@"I should see a ""(.*)"" section")]
        [Then(@"I should see an ""(.*)"" section")]
        public void ThenIShouldSeeASection(string sectionTitle)
        {
            SeleniumController.SleepWaitTime(2000);
            var section = GetSection(sectionTitle);
            if (section == null)
                throw new Exception("A heading with the text '" + sectionTitle + "' could not be found.");
        }

        [Then(@"the ""(.*)"" section should ""(.*)""")]
        public void ThenTheSectionShould(string sectionTitle, string sectionDescription)
        {
            return;
        }

        [Then(@"the ""([^""]+)"" section should contain the following links")]
        public void ThenTheSectionShouldContainTheFollowingLinks(string sectionTitle, Table table)
        {
            var missingLinks = new StringBuilder("The following links were missing: \n");
            var missingItems = false;
            foreach (var link in table.Rows)
            {
                var linkText = link["LinkText"];
                var links = SeleniumController.Instance.Driver.FindElements(By.LinkText(linkText));
                if (links.Count <= 0)
                {
                    missingItems = true;
                    missingLinks.Append("'" + linkText + "'\n");
                }
            }
            if (missingItems)
                throw new Exception(missingLinks.ToString());
        }

        [Then(@"I should see the ""(.*)"" page")]
        public void ThenIShouldSeeThePage(string title)
        {
            var found = false;
            SeleniumController.SleepWaitTime(1500);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div[2]/h1"), 30);
            var headings = SeleniumController.Instance.Driver.FindElements(By.XPath("/html/body/div[2]/h1"));
            foreach (var heading in headings)
            {
                if (heading.Text == title)
                    found = true;
            }
            if (!found)
                throw new Exception("A heading with the text '" + title + "' could not be found.");
        }

        [Then(@"the page should ""(.*)""")]
        public void ThenThePageShould(string p0)
        {
            var found = false;
            SeleniumController.SleepWaitTime(1500);
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div[2]/h2"), 30);
            var headings = SeleniumController.Instance.Driver.FindElements(By.XPath("/html/body/div[2]/h2"));
            foreach (var heading in headings)
            {
                if (heading.Text == p0)
                    found = true;
            }
            if (!found)
                throw new Exception("A heading with the text '" + p0 + "' could not be found.");

        }

        [Then(@"the page should be reviewed within the last ""(.*)"" months")]
        public void ThenThePageShouldBeReviewedWithinTheLastMonths(int numberOfMonths)
        {
            var validDate = false;
            var reviewParagraph = SeleniumController.Instance.Driver.FindElement(By.CssSelector("p.reviewed"));
            var reviewText = reviewParagraph.Text;
            var indexOfEndDate = reviewText.IndexOf(" by ");
            if (indexOfEndDate < 0)
            {
                throw new Exception("The reviewed string did not specify who it was by (did not contain ' by ')");
            }
            var indexOfStartDate = reviewText.IndexOf(" on ") + 4;
            if (indexOfEndDate < 0)
            {
                throw new Exception("The reviewed string did not specify when it was performed (did not contain ' on ')");
            }
            var dateString = reviewText.Substring(indexOfStartDate, indexOfEndDate - indexOfStartDate);
            DateTime reviewedDate = new DateTime();
            if (DateTime.TryParse(dateString, out reviewedDate))
            {
                if (reviewedDate > DateTime.Now.AddMonths(-numberOfMonths))
                {
                    validDate = true;
                }
            }

            if (!validDate)
            {
                throw new Exception("The reviewed date is older than today minus " + numberOfMonths + " months.");
            }
        }

        [When(@"I run the tests")]
        public void WhenIRunTheTests()
        {
            return;
        }

        [Then(@"all links in the documentation should be to valid pages")]
        public void ThenAllLinksInTheDocumentationShouldBeToValidPages()
        {
            SiteValidator validator = new SiteValidator();
            validator.RegisterPageValidator(new DocPageValidator());
            validator.ValidateSite(new Uri(TestSettings.Instance.DocsUrl + "/"));
            string logs = validator.GetLogs();
            string messages = validator.GetErrorMessages();
            if (messages.Length > 0)
                throw new Exception("The following links had dead ends:\n" + messages + "\nLogs:\n" + logs);
        }

    }
}
