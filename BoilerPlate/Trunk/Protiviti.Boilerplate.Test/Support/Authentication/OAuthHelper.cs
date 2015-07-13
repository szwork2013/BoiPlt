using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Protiviti.Boilerplate.Test.Support.Authentication
{
    public class OAuthHelper
    {
        internal static async Task<HttpResponseMessage> GetAccessToken(IEnumerable<KeyValuePair<string, string>> credentials)
        {
            return await PostForm(credentials, TestSettings.Instance.TokenAccessRelativeUrl);
        }

        internal static async Task<HttpResponseMessage> PostForm(IEnumerable<KeyValuePair<string, string>> formParameters, string path)
        {
            var client = HttpClientFactory.Create();
            var builder = new UriBuilder(new Uri(TestSettings.Instance.ServerUrl));
            builder.Path += path;

            var httpResponse = await client.PostAsync(builder.Uri, new FormUrlEncodedContent(formParameters));
            return httpResponse;
        }

        internal static async Task<HttpResponseMessage> GetData(string path,string accessToken)
        {
            var client = HttpClientFactory.Create();
            var builder = new UriBuilder(new Uri(TestSettings.Instance.ServerUrl));
            builder.Path += path;
            //Setting authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var httpResponse = await client.GetAsync(builder.Uri);
            return httpResponse;
        }

        internal static IEnumerable<KeyValuePair<string, string>> GetCredentialsDictionary(TokenParameters tokenRequest)//(string grantType, string apiKey = null, string apiSecret = null, string userName = null, string userPassword = null)
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(tokenRequest.ClientId))
            {
                dict.Add("client_id", tokenRequest.ClientId);
            }

            if (!string.IsNullOrEmpty(tokenRequest.ClientSecret))
            {
                dict.Add("client_secret", tokenRequest.ClientSecret);
            }

            if (!string.IsNullOrEmpty(tokenRequest.UserName))
            {
                dict.Add("username", tokenRequest.UserName);
            }

            if (!string.IsNullOrEmpty(tokenRequest.Password))
            {
                dict.Add("password", tokenRequest.Password);
            }
            if (!string.IsNullOrEmpty(tokenRequest.GrantType))
            {
                dict.Add("grant_type", tokenRequest.GrantType);
            }
            return dict;
        }


    }

    /// <summary>
    /// OAuth2 grant types
    /// </summary>
    public class OAuthGrantTypes
    {
        public const string Client_Credentials_Grant = "client_credentials";
        public const string Resource_Owner_Credentials_Grant = "password";
        public const string Authorization_Code_Grant = "authorization_code";
    }

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty(".issued")]
        public string IssuedAt { get; set; }

        [JsonProperty(".expires")]
        public string ExpiresAt { get; set; }
        //public HttpStatusCode StatusCode { get; set; }

    }

    public class ResponseError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }

    public class TokenParameters
    {
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

 }
