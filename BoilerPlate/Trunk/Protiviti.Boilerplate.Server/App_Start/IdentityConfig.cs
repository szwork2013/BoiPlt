using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using Protiviti.Boilerplate.Server.Api.Account;
using System.Net.Mail;
using System.Net.Mime;
using Protiviti.Boilerplate.Server.Api.Helper;
using Twilio;
using System.Configuration;
using System.Diagnostics;

namespace Protiviti.Boilerplate.Server
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            //var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            //var manager = new ApplicationUserManager(new UserStore<ApplicationUser>( new ApplicationDbContext()));
            var manager = new ApplicationUserManager(
            new UserStore<ApplicationUser>(
                context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
                
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;



            // Register two factor authentication providers. This application uses 
            // Phone and Emails as a step of receiving a code for verifying 
            // the user You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode",
                new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });

            manager.RegisterTwoFactorProvider("EmailCode",
               new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public virtual async Task<IdentityResult> AddUserToRolesAsync(
        string userId, IList<string> roles)
        {
            var userRoleStore = (IUserRoleStore<ApplicationUser, string>)Store;
            var user = await FindByIdAsync(userId).ConfigureAwait(false);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user Id");
            }

            var userRoles = await userRoleStore
                .GetRolesAsync(user)
                .ConfigureAwait(false);

            // Add user to each role using UserRoleStore
            foreach (var role in roles.Where(role => !userRoles.Contains(role)))
            {
                await userRoleStore.AddToRoleAsync(user, role).ConfigureAwait(false);
            }

            // Call update once when all roles are added
            return await UpdateAsync(user).ConfigureAwait(false);
        }

        public virtual async Task<IdentityResult> RemoveUserFromRolesAsync(
        string userId, IList<string> roles)
        {
            var userRoleStore = (IUserRoleStore<ApplicationUser, string>)Store;
            var user = await FindByIdAsync(userId).ConfigureAwait(false);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user Id");
            }

            var userRoles = await userRoleStore
                .GetRolesAsync(user)
                .ConfigureAwait(false);

            // Remove user to each role using UserRoleStore
            foreach (var role in roles.Where(userRoles.Contains))
            {
                await userRoleStore
                    .RemoveFromRoleAsync(user, role)
                    .ConfigureAwait(false);
            }

            // Call update once when all roles are removed
            return await UpdateAsync(user).ConfigureAwait(false);
        }


        //public virtual async Task<IdentityResult> AddUserClaimAsync(string userId, string type, string value)
        //{
        //    var userRoleStore = (IUserRoleStore<ApplicationUser, string>)Store;
        //    var user = await FindByIdAsync(userId).ConfigureAwait(false);

        //    if (user == null)
        //    {
        //        throw new InvalidOperationException("Invalid user Id");
        //    }

        //    IdentityUserClaim newClaim = new IdentityUserClaim()
        //    {
        //        UserId = userId,
        //        ClaimType = type,
        //        ClaimValue = value
        //    };

        //    if (!user.Claims.Any(x => x.ClaimType == type && x.ClaimValue == value))
        //    {
        //        user.Claims.Add(newClaim);
        //    }

        //}
        //public virtual async Task<IdentityResult> RemoveUserClaimAsync(string userId, string type, string value)
        //{

        //}
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {

        }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<IdentityRole>(
                    context.Get<ApplicationDbContext>()));

            return manager;
        }
    }


    public class ApplicationUserRole : IdentityUserRole<long> { }
    public class ApplicationUserClaim : IdentityUserClaim<long> { }

    public class ApplicationUserLogin : IdentityUserLogin<long> { }

    /// <summary>
    /// Class used to send email notification after registration for further verification
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            string text = message.Body;
            string html = message.Body;
            //do whatever you want to the message        
            MailMessage msg = new MailMessage();
            try
            {
                msg.From = new MailAddress("ajay.singh@protiviti.co.in");
                msg.To.Add(new MailAddress(message.Destination));
                msg.Subject = message.Subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient smtpClient = new SmtpClient(ServerSettings.Instance.EmailServer);
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(Keys.EmailUser, Keys.EMailKey);
                //smtpClient.Credentials = credentials;
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return Task.FromResult(0);
        }
    }


    /// <summary>
    /// Class used to send sms notification after registration for further verification
    /// </summary>
    public class SmsService : IIdentityMessageService
    {
        /// <summary>
        /// Send sms
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            var Twilio = new TwilioRestClient(ServerSettings.Instance.Twilio_Sid,ServerSettings.Instance.Twilio_Token);
            var result = Twilio.SendSmsMessage(ServerSettings.Instance.Twilio_FromPhone, message.Destination, message.Body);

            // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
            Trace.TraceInformation(result.Status);

            // Twilio doesn't currently have an async API, so return success.
            return Task.FromResult(0);
        }
    }

}
