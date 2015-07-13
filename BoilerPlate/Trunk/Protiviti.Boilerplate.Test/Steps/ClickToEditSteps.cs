using Protiviti.Boilerplate.Test.Helper;
using System;
using TechTalk.SpecFlow;
using Protiviti.Boilerplate.Test.Support;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class ClickToEditSteps
    {
        [Then(@"I should see a list of editable controls")]
        public void ThenIShouldSeeAListOfEditableControls()
        {
            DriverHelper.GetHeading2ByTitle("Click To Edit (Form)");
        }

        [Then(@"I click on ""(.*)"" to edit")]
        public void ThenIClickOnToEdit(string p0)
        {
            SeleniumController.SleepWaitTime(2000);
            DriverHelper.GetElementByName(p0).Click();
        }
    }
}
