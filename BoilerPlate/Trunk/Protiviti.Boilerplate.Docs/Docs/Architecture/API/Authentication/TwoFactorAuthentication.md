Two-Factor Authentication
=========================

This system implements two-factor authentication with the help of asp.identity. Every time internal user register into system
using registration page an email with verification code is sent to email id used during registration process.
Also user is redirected to verification page where user needs to enter the code received from email to verify himself.
The code send is only valid for <b>3 mins</b>

if user somehow don't receive email he can again make request for the code either by Email or SMS.

For SMS notification, we are using Twilio Api's. In test account, SMS functionality is not working for India numbers.

###Prerequisites
* Familiarity with Asp.Net Identity

####Note
* Two-factor authentication is not applicable to external logins for e.g. Google or Facebook

###Resources
* [SMS and email Two-Factor Authentication](http://www.asp.net/mvc/overview/security/aspnet-mvc-5-app-with-sms-and-email-two-factor-authentication)

<p class="updated">Updated on 11/17/2014 by Ajay Singh</p>
<p class="reviewed">Reviewed on 11/17/2014 by Ajay Singh</p>
