#Registration
-------------------------

## Overview ##
The application lets user register into the Boilerplate system. It presents the user with a form with some mandatory and optional fields.


The *Login Information* section requires the following details from the user:

 * **Email**: This is a required field. This field accepts text in form of a valid email address, with a minimum length of 3 characters.
 * **Confirm Email**: This is a required field. The text entered in this field should exactly match the text in 'Email' column.
 * **Password**: This is a required field. The password must have at least one non letter or digit character, at least one digit ('0'-'9') and at least one uppercase ('A'-'Z'). Minimum length of the password is 6 characters.
 * **Confirm Password**: This is a required field. The text entered in this field should exactly match the text in 'Password' column.

The *Contact Information* section requires the following details from the user:

* **Salutation**: The user can select his/her salutation from the dropdown menu.
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
* **State/Province**: This is a required field. The user can select his/her state province from the dropdown, which is populated as per the country selected.
* **Zip/Postal Code**

After filling the above information, the user is required to agree to the terms and conditions by checking the checkbox provided.

Once all the information is filled, the user can click on the submit button. In case any of the mandatory fields are left empty or if any validation rule is not met, the corresponding validation error message is displayed on the screen.


![Registration](/Protiviti.Boilerplate.Docs/images/authentication/registration.jpg)

<p class="updated">Updated on 11/24/2014 by Shruti Pandey</p>
<p class="reviewed">Reviewed on 11/25/2014 by Chandana Koti</p>

