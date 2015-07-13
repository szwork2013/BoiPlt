#Change Profile
-------------------------

## Overview ##
The application lets the user change his/her profile details. The user is presented with a form pre-populated with the saved details as described below.

The *Contact Information* section requires the following details from the user:

* **Salutation**: The user can edit his/her salutation from the dropdown menu.
* **First Name**: This is a required field. The maximum length of user's first name is 20 characters.
* **Last Name**: This is a required field. The maximum length of user's last name is 20 characters.
* **Suffix**
* **Title**
* **Phone Number**: This is a required field. The field accepts text in form of a valid phone number.
* **Fax**
* **Cell**

The *Work Address* section requires the following details from the user:

* **Address Line 1**: This is a required field.
* **Address Line 2**
* **City**: This is a required field.
* **Country**: This is a required field. The user can select his/her country from the dropdown. Currently only two countries namely- United States and India are provided.
* **State/Province**: This is a required field. The user can select his/her state province from the dropdown. NOTE: Currently, the dropdown is not getting filtered as per the country selected.
* **Zip/Postal Code**

Once all the information is filled, the user can click on the submit button. In case any of the mandatory fields are left empty or if any validation rule is not met, the corresponding validation error message is displayed on the screen.

If all the changes are successfully updated,a success message is displayed. In case the user clicks on Cancel, he/she is redirected to the dashboard.

![Change Profile](/Protiviti.Boilerplate.Docs/images/userprofile/changeprofile.png)




<p class="updated">Updated on 11/25/2014 by Shruti Pandey</p>
<p class="reviewed">Reviewed on 11/26/2014 by Ajay Singh</p>