using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Protiviti.Boilerplate.Test.Support.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using Shouldly;

namespace Protiviti.Boilerplate.Test.Steps.Authentication
{
    [Binding]
    public class OAuthResourceOwnerPasswordCredentialsGrantSteps
    {
        /// <summary>
        /// Token request format
        /// grant_type is set to "password". which you need to set if want to use OAth "Resource Owner PAssword Credential" Option
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> tokenRequest = null;
        TokenResponse tokenResponse = null;
        ResponseError responseError = null;
        private TokenParameters tokenParameters;
        int totalEmployees = 0;
        string employees = string.Empty;

        public OAuthResourceOwnerPasswordCredentialsGrantSteps()
        {
            tokenParameters = new TokenParameters
            {
                GrantType = OAuthGrantTypes.Resource_Owner_Credentials_Grant.ToString(),
                UserName = "admin@protiviti.com",
                Password = "Admin@123"
            };
        }

        [Given(@"I created the post request ""(.*)""")]
        public void GivenICreatedThePostRequest(string p0)
        {
            tokenRequest = OAuthHelper.GetCredentialsDictionary(tokenParameters);
        }

        [When(@"I make a call to ""(.*)""")]
        public void WhenIMakeACallTo(string p0)
        {
            try
            {
                var task = OAuthHelper.GetAccessToken(tokenRequest);
                task.Wait();
                var response = task.Result;
                var result = response.Content.ReadAsStringAsync();
                result.Wait();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result.Result);
                }
                else
                {
                    responseError = JsonConvert.DeserializeObject<ResponseError>(result.Result);
                }
            }
            catch (Exception ex)
            { }
        }

        [Then(@"I should get a valid response")]
        public void ThenIShouldGetAValidResponse()
        {
            Assert.IsNotNull(tokenResponse);
        }

        [Then(@"I should get the access token")]
        public void ThenIShouldGetTheAccessToken()
        {
            Assert.IsNotNull(tokenResponse);
            Assert.IsNotNull(tokenResponse.AccessToken);
        }

        [Then(@"I should get the same username as passed with credentials for e\.g\. admin@protiviti\.com")]
        public void ThenIShouldGetTheSameUsernameAsPassedWithCredentialsForE_G_AdminProtiviti_Com()
        {
            var userName = string.Empty;
            foreach (KeyValuePair<string, string> item in tokenRequest)
            {
                if (item.Key == "username")
                {
                    userName = item.Value;
                    break;
                }
            }
            Assert.AreEqual(tokenResponse.Username, userName);
        }

        [Then(@"I should get the access token which expires in (.*) day")]
        public void ThenIShouldGetTheAccessTokenWhichExpiresInDay(int p0)
        {
            Assert.IsNotNull(tokenResponse);
            // 1 Day=86400 Seconds. Token expires 1 second before
            Assert.AreEqual(tokenResponse.ExpiresIn, 86399);
        }

        [Then(@"I should get the Bearer access token type")]
        public void ThenIShouldGetTheBearerAccessTokenType()
        {
            Assert.IsNotNull(tokenResponse);
            Assert.AreEqual(tokenResponse.TokenType, "bearer");
        }

        [Given(@"I have a valid access token")]
        public void GivenIHaveAValidAccessToken()
        {
            //Creating token request parameters
            tokenRequest = OAuthHelper.GetCredentialsDictionary(tokenParameters);
            // Making token request
            WhenIMakeACallTo(string.Empty);
        }

        [When(@"I make a call to secure resource employee ""(.*)""")]
        public void WhenIMakeACallToSecureResourceEmployee(string p0)
        {
            if (tokenResponse != null)
            {

                var task = OAuthHelper.GetData("/api/employee/employees", tokenResponse.AccessToken);
                task.Wait();
                var response = task.Result;
                var employeeData = response.Content.ReadAsStringAsync();
                employeeData.Wait();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    employees = employeeData.Result;
                }
                else
                {
                }
            }
        }

        [Then(@"I should get the list of employees where total count should be greater than Zero")]
        public void ThenIShouldGetTheListOfEmployeesWhereTotalCountShouldBeGreaterThanZero()
        {
            employees.ShouldNotBeNullOrEmpty();
            //Assert.AreNotSame(employees, string.Empty);
            var empCount = ((JArray)JsonConvert.DeserializeObject(employees)).Count;
            empCount.ShouldBeGreaterThan(0);
            //Assert.IsTrue(empCount > 0, "If employee data is present in database then we should get employee list.");
        }

        [Given(@"I created the post request with incorrect values for parameters grant_type ""(.*)"" , username ""(.*)"" and password ""(.*)""")]
        public void GivenICreatedThePostRequestWithIncorrectValuesForParametersGrant_TypeUsernameAndPassword(string p0, string p1, string p2)
        {
            tokenParameters.GrantType = p0;
            tokenParameters.UserName = p1;
            tokenParameters.Password = p2;
            tokenRequest = OAuthHelper.GetCredentialsDictionary(tokenParameters);
        }

        [Then(@"I should not get the access token")]
        public void ThenIShouldNotGetTheAccessToken()
        {
            Assert.IsNotNull(responseError);
            Assert.IsNull(tokenResponse);
        }

        //[Given(@"I created the post request with incorrect credential values ""(.*)""")]
        //public void GivenICreatedThePostRequestWithIncorrectCredentialValues(string p0)
        //{
        //    ScenarioContext.Current.Pending();
        //}

        [Then(@"I should get error of invalid grant")]
        public void ThenIShouldGetErrorOfInvalidGrant()
        {
            Assert.IsNotNull(responseError);
            Assert.AreEqual(responseError.Error, "invalid_grant");
        }

        [Given(@"I created the post request with invalid grant type ""(.*)""")]
        public void GivenICreatedThePostRequestWithInvalidGrantType(string p0)
        {
            tokenParameters.GrantType = "testgrant";
            tokenRequest = OAuthHelper.GetCredentialsDictionary(tokenParameters);
        }

        [Then(@"I should get error of unsupported grant type")]
        public void ThenIShouldGetErrorOfUnsupportedGrantType()
        {
            Assert.IsNotNull(responseError);
            Assert.AreEqual(responseError.Error, "unsupported_grant_type");
        }

        [Given(@"I created the post request with incorrect grant type ""(.*)""")]
        public void GivenICreatedThePostRequestWithIncorrectGrantType(string p0)
        {
            tokenParameters.GrantType = OAuthGrantTypes.Client_Credentials_Grant;
            tokenRequest = OAuthHelper.GetCredentialsDictionary(tokenParameters);
        }

        [Then(@"I should get error of unauthorized client")]
        public void ThenIShouldGetErrorOfUnauthorizedClient()
        {
            Assert.IsNotNull(responseError);
            Assert.AreEqual(responseError.Error, "unauthorized_client");
        }

        [Given(@"I created the post request with incorrect values for parameters username ""(.*)"" and password ""(.*)""")]
        public void GivenICreatedThePostRequestWithIncorrectValuesForParametersUsernameAndPassword(string p0, string p1)
        {
            tokenParameters.UserName = p0;
            tokenParameters.Password = p1;
            tokenRequest = OAuthHelper.GetCredentialsDictionary(tokenParameters);
        }
    }
}
