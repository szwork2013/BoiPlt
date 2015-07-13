using Protiviti.Boilerplate.Test.Helper;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class InjectDatabaseContextToControllerSteps
    {
        [When(@"I enter page reference InjectDatabaseContextToController ""(.*)""")]
        public void WhenIEnterPageReferenceInjectDatabaseContextToController(string p0)
        {
            DriverHelper.NavigateToDocumentationUrl(p0);
        }

        [Then(@"I should see the documentation on how to inject database context to a controller ""(.*)""")]
        public void ThenIShouldSeeTheDocumentationOnHowToInjectDatabaseContextToAController(string p0)
        {
            var heading = DriverHelper.GetHeadingByTitle(p0);
            if (heading == null)
                throw new Exception("A heading with the text '" + p0 + "' could not be found.");

        }
    }
}
