using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protiviti.Boilerplate.Test.Pages;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class SearchEntityListWithExpandedEntitiesUIServiceSteps
    {
        [Then(@"I should see a list of application with program, applicant, invoice and payment information")]
        public void ThenIShouldSeeAListOfApplicationWithProgramApplicantInvoiceAndPaymentInformation()
        {
            Assert.IsTrue(ApplicationsPage.IsAt(), "Failed to load applications.");
        }

        [Then(@"I should see status column ""(.*)""")]
        public void ThenIShouldSeeStatusColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have status column.");
        }

        [Then(@"I should see program name column ""(.*)""")]
        public void ThenIShouldSeeProgramNameColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have program name column.");
        }

        [Then(@"I should see applicant name column ""(.*)""")]
        public void ThenIShouldSeeApplicantNameColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have applicant name column.");
        }

        [Then(@"I should see applicant email column ""(.*)""")]
        public void ThenIShouldSeeApplicantEmailColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have email column.");
        }

        [Then(@"I should see applicant company column ""(.*)""")]
        public void ThenIShouldSeeApplicantCompanyColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have company column.");
        }

        [Then(@"I should see applicant department column ""(.*)""")]
        public void ThenIShouldSeeApplicantDepartmentColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have department column.");
        }

        [Then(@"I should see invoice amount column ""(.*)""")]
        public void ThenIShouldSeeInvoiceAmountColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have amount column.");
        }

        [Then(@"I should see payment account number column ""(.*)""")]
        public void ThenIShouldSeePaymentAccountNumberColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have account name column.");
        }

        [Then(@"I should see payment routing number column ""(.*)""")]
        public void ThenIShouldSeePaymentRoutingNumberColumn(string p0)
        {
            Assert.IsTrue(ApplicationsPage.Has(p0), "Results table does not have routing number column.");
        }
    }
}
