Login Functionality
===================================
The login functionality of the application is divided into following 2 parts:
<br />
	1. Authentication
<br />
	2. Authorization
<br />

 Overview 
------------------
The login section of the application allows the users to log in the system by entering username and password in the respective fields. The users need to be registered before logging in the system.

* Login Section- The login section of the application contains a username field with a placeholder 'Username' on it, a password field with a placeholder 'Password' on it, a Login and a Reset button.
				 The login section also contains a hyperlink to the Registration form for the new users to register.
<br />
![Login Section](/Protiviti.Boilerplate.Docs/images/Authentication/Login.jpg)

* Login Button- The button gets enabled when there is text in username and password fields. On clicking, the user navigates to the appropriate content depending upon the login credentials.

* Reset Button- On clicking this button, the text in the username and password fields are reset 

* Successful Login- On entering correct username and password and clicking the Login button, the user is logged in, navigated to the dashboard and sees a welcome message in the navigation bar and is authenticated to the application.

* Unsuccessful Login- On entering incorrect either of the username or password or both, the user sees an alert message for the invalid login. 

* Role-Based Authorization- There are different roles in the system such as Admin, Member etc. When a user is authenticated to the application, he/ she might not be authorized to access all the content in the application.
							The user with the Admin Role can access all the content in the application.
							The user with only the Member Role cannot access the 'Manage' item of the Admin section
							The Non-Admin and Non-Admin users cannot access the 'Employees' menu item as well as the 'Manage' menu item
							Multiple roles can be assigned to a single user.

* External login- The application also provides support for external login. 

<p class="updated">Updated on 11/18/2014 by Rohan Gambhir</p>
<p class="reviewed">Reviewed on 11/21/2014 by Rohan Gambhir</p>