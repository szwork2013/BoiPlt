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
    public class ClientSidePaginationSteps
    {
        [Given(@"a database table ""(.*)"" having the following rows:")]
        public void GivenADatabaseTableHavingTheFollowingRows(string p0, Table table)
        {
            
        }

        [Given(@"I am viewing a client-side paginated grid generated from table ""(.*)""")]
        public void GivenIAmViewingAClient_SidePaginatedGridGeneratedFromTable(string p0)
        {
            //done
            Pages.PageNavigator.NavigatePage("DemoGrid");
           

        }

        [Given(@"the grid ""(.*)"" has (.*) lines per page")]
        public void GivenTheGridHasLinesPerPage(string tableName, int rowsAllowed)
        {
            //done
            Pages.GridDemoPage.DataRowsCount(tableName, rowsAllowed);
        }
        [When(@"the grid ""(.*)"" has (.*) lines per page")]
        public void WhenTheGridHasLinesPerPage(string tableName, int rowsAllowed)
        {
            //done
            Pages.GridDemoPage.DataRowsCount(tableName, rowsAllowed);
        }

        [Then(@"Page numbers showing is total Items devided by lines allowed by grid")]
        public void ThenPageNumbersShowingIsTotalItemsDevidedByLinesAllowedByGrid()
        {
            //done
            int rowsAllowed = 3;
            Assert.IsTrue(Pages.GridDemoPage.ValidateTablePageCount(rowsAllowed), "The number of pages is incorrect");
            
            
        }

        [When(@"I view the grid")]
        public void WhenIViewTheGrid()
        {
            //done
            Assert.IsTrue(Pages.GridDemoPage.CheckLocalDataGridIsPresent(), "Couldnt find the local data grid table");       
        }

        [Then(@"GridDemo Page should successfully load")]
        public void ThenGridDemoPageShouldSuccessfullyLoad()
        {
            
            Assert.IsTrue(Pages.GridDemoPage.IsAt(), "You didnt arrive to the GridDemo page as expected");
            
           
        }

        [Then(@"The page with the grid loads and all of the lines of data are retrieved from the server")]
        public void ThenThePageWithTheGridLoadsAndAllOfTheLinesOfDataAreRetrievedFromTheServer()
        {
            //get Data from Data base and check them in the table
            //this bart can be only implemented once the data starting coming from the DB instead of being hardcoded.
            //to talk to Alok and move forward with it.         
        }

        [Then(@"The first (.*) lines of data are displayed in the grid")]
        public void ThenTheFirstLinesOfDataAreDisplayedInTheGrid(int p0)
        {
            //the first three items populatedin the first three lines.
        }

        [Then(@"the page number (.*) is highlighted")]
        public void ThenThePageNumberIsHighlighted(int p0)
        {
            //pending
            
        }

    }
}
