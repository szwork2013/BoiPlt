using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Protiviti.Boilerplate.Server.Api.Helper
{
    /// <summary>
    /// Help to get app settings configured in web.config file
    /// </summary>
    public class ServerSettings
    {
        /// <summary>
        /// Single instance of server settings
        /// </summary>
        public static ServerSettings Instance = new ServerSettings();

        /// <summary>
        /// Google Client Id
        /// </summary>
        /// <returns></returns>
        public string Google_Client_Id { get; set; }

        /// <summary>
        /// Google client Secret key
        /// </summary>
        /// <returns></returns>
        public string Google_Client_Secret { get; set; }

        /// <summary>
        /// Facebook App Id
        /// </summary>
        /// <returns></returns>
        public string Facebook_App_Id { get; set; }

        /// <summary>
        /// Facebook client Secret key
        /// </summary>
        /// <returns></returns>
        public string Facebook_App_Secret { get; set; }

        /// <summary>
        /// Facebook app token used to verify the token received from facebook after authentication
        /// </summary>
        /// <returns></returns>
        public string Facebook_App_Token { get; set; }

        /// <summary>
        /// SMTP server used to send emails
        /// </summary>
        /// <returns></returns>
        public string EmailServer { get; set; }

        // On the Dashboard near the top you will find your AccountSid and AuthToken. 
        // Copy those values and paste them into AccountSid and AuthToken variables. 
        public string Twilio_Sid { get; set; }

        public string Twilio_Token { get; set; }

        // The From parameter should be the Sandbox phone number for trial accounts 
        // or an SMS-enabled Twilio phone number you purchased for upgraded accounts.

        public string Twilio_FromPhone { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ServerSettings()
        {
            Google_Client_Id = ConfigurationManager.AppSettings["Google_ClientId"];
            Google_Client_Secret = ConfigurationManager.AppSettings["Google_ClientKey"];
            Facebook_App_Id = ConfigurationManager.AppSettings["Facebook_ClientId"];
            Facebook_App_Secret = ConfigurationManager.AppSettings["Facebook_ClientKey"];
            Facebook_App_Token = ConfigurationManager.AppSettings["Facebook_AppToken"];
            EmailServer = ConfigurationManager.AppSettings["EmailServer"];
            Twilio_Sid = ConfigurationManager.AppSettings["SMSSID"];
            Twilio_Token = ConfigurationManager.AppSettings["SMSAuthToken"];
            Twilio_FromPhone = ConfigurationManager.AppSettings["SMSPhoneNumber"];
        }
    }
}