using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Helper;
using Protiviti.Boilerplate.Test.Support;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class DocumentGroupEntitiesByDatabaseSchemaSteps
    {
        private IWebElement GetHeading(string sectionTitle)
        {
            IWebElement found = null;
            var subHeadings = SeleniumController.Instance.Driver.FindElements(By.TagName("h1"));
            foreach (var subHeading in subHeadings)
            {
                if (subHeading.Text == sectionTitle)
                    found = subHeading;
            }
            return found;
        }

        [When(@"I enter page reference DocumentGroupEntitiesByDatabaseSchema ""(.*)""")]
        public void WhenIEnterPageReferenceDocumentGroupEntitiesByDatabaseSchema(string p0)
        {
            DriverHelper.NavigateToDocumentationUrl(p0);
        }

        [Then(@"I should see the documentation on how to specify database schema name for my entities ""(.*)""")]
        public void ThenIShouldSeeTheDocumentationOnHowToSpecifyDatabaseSchemaNameForMyEntities(string p1)
        {
            var section = GetHeading(p1);
            if (section == null)
                throw new Exception("A heading with the text '" + p1 + "' could not be found.");
        }
    }
}
