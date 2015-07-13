#Change Password
-------------------------

## Overview ##
The application lets the user change his/her login password. The user is presented with a form with all required fields, as described below.

* **Old Password**: The user is required to enter his current login password.
* **New Password**: The user should enter his new password for login. This cannot be same as the old password. The password must have at least one non letter or digit character, at least one digit ('0'-'9') and at least one uppercase ('A'-'Z'). Minimum length of the password is 6 characters. 
* **Confirm Password**: The user should re-enter his/her new password and the text should exactly match the one entered in the *New Password* field.

Once all the information is filled, the user can click on the submit button. In case any of the mandatory fields are left empty or if any validation rule is not met, the corresponding validation error message is displayed on the screen.

If all the changes are successfully updated, a success message is displayed. After a gap of 4 seconds, the user is redirected to the login screen. Now, the user should log in with his id and the new password.
In case the user clicks on Cancel, he/she is redirected to the dashboard.

![Change Password](/Protiviti.Boilerplate.Docs/images/userprofile/changepassword.jpg)




<p class="updated">Updated on 11/24/2014 by Shruti Pandey</p>
<p class="reviewed">Reviewed on 11/26/2014 by Ajay Singh</p>

