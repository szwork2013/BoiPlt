using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Pages;
using Protiviti.Boilerplate.Test.Support;
using System;
using TechTalk.SpecFlow;
using System.Threading;


namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class FilterSteps
    {
        [Given(@"I am viewing a grid on the gridDemo page")]
        public void GivenIAmViewingAGridOnTheGridDemoPage()
        {
            GridDemoPage.GoTo();
            Thread.Sleep(2000);
           // GridDemoPage.CheckURL();
        }

        [When(@"I apply a (.*) filter with filter value (.*) to column (.*) type")]
        public void WhenIApplyAnEqualsFilterWithFilterValueToColumnType(string filterText, string filterValue, string column)
        {
            var gridObject = GridDemoPage.GetGridObjectById("PRO_localGridWithSortFilter");
            gridObject.ClickFilterForColumn("LastName");
            
            GridDemoPage.FilterValue(filterValue);
            SeleniumController.SleepWaitTime(2000);
            GridDemoPage.SelectFilterTypeInDropdown(filterText);
          
        }

        [Then(@"the grid should show (.*) rows with MyString values of (.*)")]
        public void ThenTheGridShouldShowRowsWithMyStringValuesOf(int resultRowCount, string resultRowValues)
        {
            SeleniumController.SleepWaitTime(2000);

            var results = resultRowValues.Split(',');

            var gridObject = GridDemoPage.GetGridObjectById("PRO_localGridWithSortFilter");
            var rowCountElement = gridObject.GetRowCountElement();

            var rowCountSplit = rowCountElement.Text.Split(' ');
            int count;
            if (int.TryParse(rowCountSplit[rowCountSplit.Length - 2], out count) == false)
            { 
                Assert.Fail("Invalid count"); 
            }
            else
            {
                Assert.AreEqual<int>(resultRowCount, count);
            }
            
            var resultRows = gridObject.GetDisplayedResultRows();

            foreach (var resultRow in resultRows)
            {
                if (!resultRowValues.Contains(resultRow.FindElement(By.CssSelector("td")).Text))
                {
                    Assert.Fail(String.Format("Filtered result includes LastName of {0}, which is not an expected value.", resultRow.Text));
                }
            }
        }

        private void SleepWaitTime(int p)
        {
            throw new NotImplementedException();
        }

        private void sleepwaittime(int p)
        {
            throw new NotImplementedException();
        }
    }
}


