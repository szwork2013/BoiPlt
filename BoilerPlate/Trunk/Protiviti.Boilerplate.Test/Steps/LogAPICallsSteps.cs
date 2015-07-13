using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protiviti.Boilerplate.Test.Features.Architecture.API.Authentication;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class LogApiCallsSteps
    {
        [Given(@"I have set the api logging level to ""(.*)""")]
        public void GivenIHaveSetTheApiLoggingLevelTo(string p0)
        {
            //Logging.GoTo();
            //Logging.SetLoggingLevel(p0); 
        }

        [When(@"I make a request to the api")]
        public void WhenIMakeARequestToTheApi()
        {
            //Logging.SubmitRequestToAPI(); 
        }

        [Then(@"the request should not be logged to the database")]
        public void ThenTheRequestShouldNotBeLoggedToTheDatabase(Table table)
        {
            //Database.GoTo().Login();
            //Database.OpenLoggingTable();
            //Database.SearchForLoggingTableRecord();
            //Assert.IsTrue(Database.DoesLoggingRecordExist(table), "A request was logged"); 
        }

        [Then(@"the request should be logged to the database with the following properties")]
        public void ThenTheRequestShouldBeLoggedToTheDatabaseWithTheFollowingProperties(Table table)
        {
            //Database.GoTo().Login();
            //Database.OpenLoggingTable();
            //Database.SearchForLoggingTableRecord();
            //Assert.IsTrue(Database.DoesLoggingRecordExist(table), "A request was not logged"); 
        }
    }
}