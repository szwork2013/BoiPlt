﻿using Protiviti.Boilerplate.Test.Support;
using System;
using TechTalk.SpecFlow;

namespace Protiviti.Boilerplate.Test.Steps
{
    [Binding]
    public class DefineEntityWithPrimaryKeySteps
    {
        [Then(@"I should see program entity with id property")]
        public void ThenIShouldSeeProgramEntityWithIdProperty()
        {
            var response = SeleniumController.Instance.Driver.FindElements(OpenQA.Selenium.By.TagName("pre"))[0].Text;
            if (!response.Equals("{\"schema\":{\"namespace\":\"Protiviti.Boilerplate.Server.Api.ApplicationWizard\",\"alias\":\"Self\",\"annotation:UseStrongSpatialTypes\":\"false\",\"xmlns:annotation\":\"http://schemas.microsoft.com/ado/2009/02/edm/annotation\",\"xmlns:customannotation\":\"http://schemas.microsoft.com/ado/2013/11/edm/customannotation\",\"xmlns\":\"http://schemas.microsoft.com/ado/2009/11/edm\",\"cSpaceOSpaceMapping\":\"[[\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Applicant\\\",\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Applicant\\\"],[\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Application\\\",\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Application\\\"],[\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Invoice\\\",\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Invoice\\\"],[\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Payment\\\",\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Payment\\\"],[\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Program\\\",\\\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Program\\\"]]\",\"entityType\":[{\"name\":\"Applicant\",\"customannotation:ClrType\":\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Applicant, Protiviti.Boilerplate.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"key\":{\"propertyRef\":{\"name\":\"Id\"}},\"property\":[{\"name\":\"Id\",\"type\":\"Edm.Int32\",\"nullable\":\"false\",\"annotation:StoreGeneratedPattern\":\"Identity\"},{\"name\":\"FirstName\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"LastName\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"CompanyName\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Email\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"PhoneNumber\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Department\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Track\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"}]},{\"name\":\"Application\",\"customannotation:ClrType\":\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Application, Protiviti.Boilerplate.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"key\":{\"propertyRef\":{\"name\":\"Id\"}},\"property\":[{\"name\":\"Id\",\"type\":\"Edm.Int32\",\"nullable\":\"false\",\"annotation:StoreGeneratedPattern\":\"Identity\"},{\"name\":\"Applicantid\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"},{\"name\":\"ProgramId\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"},{\"name\":\"InvoiceId\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"},{\"name\":\"Name\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Status\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"SubmittedDate\",\"type\":\"Edm.DateTime\",\"nullable\":\"false\"},{\"name\":\"CreatedDate\",\"type\":\"Edm.DateTime\",\"nullable\":\"false\"},{\"name\":\"LastChangedDate\",\"type\":\"Edm.DateTime\",\"nullable\":\"false\"}],\"navigationProperty\":[{\"name\":\"Applicant\",\"relationship\":\"Self.Application_Applicant\",\"fromRole\":\"Application_Applicant_Source\",\"toRole\":\"Application_Applicant_Target\"},{\"name\":\"Invoice\",\"relationship\":\"Self.Application_Invoice\",\"fromRole\":\"Application_Invoice_Source\",\"toRole\":\"Application_Invoice_Target\"},{\"name\":\"Program\",\"relationship\":\"Self.Application_Program\",\"fromRole\":\"Application_Program_Source\",\"toRole\":\"Application_Program_Target\"}]},{\"name\":\"Invoice\",\"customannotation:ClrType\":\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Invoice, Protiviti.Boilerplate.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"key\":{\"propertyRef\":{\"name\":\"Id\"}},\"property\":[{\"name\":\"Id\",\"type\":\"Edm.Int32\",\"nullable\":\"false\",\"annotation:StoreGeneratedPattern\":\"Identity\"},{\"name\":\"Amount\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"},{\"name\":\"PaymentId\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"},{\"name\":\"SubmitDate\",\"type\":\"Edm.DateTime\",\"nullable\":\"false\"}],\"navigationProperty\":{\"name\":\"Payment\",\"relationship\":\"Self.Invoice_Payment\",\"fromRole\":\"Invoice_Payment_Source\",\"toRole\":\"Invoice_Payment_Target\"}},{\"name\":\"Payment\",\"customannotation:ClrType\":\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Payment, Protiviti.Boilerplate.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"key\":{\"propertyRef\":{\"name\":\"Id\"}},\"property\":[{\"name\":\"Id\",\"type\":\"Edm.Int32\",\"nullable\":\"false\",\"annotation:StoreGeneratedPattern\":\"Identity\"},{\"name\":\"Type\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"},{\"name\":\"AccountNumber\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"RoutingNumber\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"PaymentDate\",\"type\":\"Edm.DateTime\",\"nullable\":\"false\"}]},{\"name\":\"Program\",\"customannotation:ClrType\":\"Protiviti.Boilerplate.Server.Api.ApplicationWizard.Program, Protiviti.Boilerplate.Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"key\":{\"propertyRef\":{\"name\":\"Id\"}},\"property\":[{\"name\":\"Id\",\"type\":\"Edm.Int32\",\"nullable\":\"false\",\"annotation:StoreGeneratedPattern\":\"Identity\"},{\"name\":\"Name\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Code\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Cost\",\"type\":\"Edm.Decimal\",\"precision\":\"18\",\"scale\":\"2\",\"nullable\":\"false\"},{\"name\":\"Location\",\"type\":\"Edm.String\",\"maxLength\":\"Max\",\"fixedLength\":\"false\",\"unicode\":\"true\"},{\"name\":\"Duration\",\"type\":\"Edm.Int32\",\"nullable\":\"false\"}]}],\"association\":[{\"name\":\"Application_Applicant\",\"end\":[{\"role\":\"Application_Applicant_Source\",\"type\":\"Edm.Self.Application\",\"multiplicity\":\"*\"},{\"role\":\"Application_Applicant_Target\",\"type\":\"Edm.Self.Applicant\",\"multiplicity\":\"1\",\"onDelete\":{\"action\":\"Cascade\"}}],\"referentialConstraint\":{\"principal\":{\"role\":\"Application_Applicant_Target\",\"propertyRef\":{\"name\":\"Id\"}},\"dependent\":{\"role\":\"Application_Applicant_Source\",\"propertyRef\":{\"name\":\"Applicantid\"}}}},{\"name\":\"Invoice_Payment\",\"end\":[{\"role\":\"Invoice_Payment_Source\",\"type\":\"Edm.Self.Invoice\",\"multiplicity\":\"*\"},{\"role\":\"Invoice_Payment_Target\",\"type\":\"Edm.Self.Payment\",\"multiplicity\":\"1\",\"onDelete\":{\"action\":\"Cascade\"}}],\"referentialConstraint\":{\"principal\":{\"role\":\"Invoice_Payment_Target\",\"propertyRef\":{\"name\":\"Id\"}},\"dependent\":{\"role\":\"Invoice_Payment_Source\",\"propertyRef\":{\"name\":\"PaymentId\"}}}},{\"name\":\"Application_Invoice\",\"end\":[{\"role\":\"Application_Invoice_Source\",\"type\":\"Edm.Self.Application\",\"multiplicity\":\"*\"},{\"role\":\"Application_Invoice_Target\",\"type\":\"Edm.Self.Invoice\",\"multiplicity\":\"1\",\"onDelete\":{\"action\":\"Cascade\"}}],\"referentialConstraint\":{\"principal\":{\"role\":\"Application_Invoice_Target\",\"propertyRef\":{\"name\":\"Id\"}},\"dependent\":{\"role\":\"Application_Invoice_Source\",\"propertyRef\":{\"name\":\"InvoiceId\"}}}},{\"name\":\"Application_Program\",\"end\":[{\"role\":\"Application_Program_Source\",\"type\":\"Edm.Self.Application\",\"multiplicity\":\"*\"},{\"role\":\"Application_Program_Target\",\"type\":\"Edm.Self.Program\",\"multiplicity\":\"1\",\"onDelete\":{\"action\":\"Cascade\"}}],\"referentialConstraint\":{\"principal\":{\"role\":\"Application_Program_Target\",\"propertyRef\":{\"name\":\"Id\"}},\"dependent\":{\"role\":\"Application_Program_Source\",\"propertyRef\":{\"name\":\"ProgramId\"}}}}],\"entityContainer\":{\"name\":\"ApplicationWizardContext\",\"customannotation:UseClrTypes\":\"true\",\"entitySet\":[{\"name\":\"Applicants\",\"entityType\":\"Self.Applicant\"},{\"name\":\"Applications\",\"entityType\":\"Self.Application\"},{\"name\":\"Invoices\",\"entityType\":\"Self.Invoice\"},{\"name\":\"Payments\",\"entityType\":\"Self.Payment\"},{\"name\":\"Programs\",\"entityType\":\"Self.Program\"}],\"associationSet\":[{\"name\":\"Application_Applicant\",\"association\":\"Self.Application_Applicant\",\"end\":[{\"role\":\"Application_Applicant_Source\",\"entitySet\":\"Applications\"},{\"role\":\"Application_Applicant_Target\",\"entitySet\":\"Applicants\"}]},{\"name\":\"Invoice_Payment\",\"association\":\"Self.Invoice_Payment\",\"end\":[{\"role\":\"Invoice_Payment_Source\",\"entitySet\":\"Invoices\"},{\"role\":\"Invoice_Payment_Target\",\"entitySet\":\"Payments\"}]},{\"name\":\"Application_Invoice\",\"association\":\"Self.Application_Invoice\",\"end\":[{\"role\":\"Application_Invoice_Source\",\"entitySet\":\"Applications\"},{\"role\":\"Application_Invoice_Target\",\"entitySet\":\"Invoices\"}]},{\"name\":\"Application_Program\",\"association\":\"Self.Application_Program\",\"end\":[{\"role\":\"Application_Program_Source\",\"entitySet\":\"Applications\"},{\"role\":\"Application_Program_Target\",\"entitySet\":\"Programs\"}]}]}}}"))
            {
                if (!response.Contains("Protiviti.Boilerplate.Server.Api.ApplicationWizard.Program") || !response.Contains("Id"))
                {
                    throw new Exception("Program does not have id property.");
                }
            }
        }
    }
}
