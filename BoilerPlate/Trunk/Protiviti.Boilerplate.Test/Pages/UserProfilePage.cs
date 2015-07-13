using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Protiviti.Boilerplate.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;


namespace Protiviti.Boilerplate.Test.Pages
{
    class UserProfilePage
    {
        public static string _intialName;
        public static string _FieldName;
        public static int _MaxLength;
        public static int _MaxLengthDB;
        private static int browerWaitTime = 1;

        public static void ClickChangeProfileItem()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("currentuser"), 80);
            IWebElement profileItem =  SeleniumController.Instance.Driver.FindElement(By.Id("currentuser"));
            profileItem.Click();
            IWebElement changeProfileItem = SeleniumController.Instance.Driver.FindElement(By.Id("changeprofile"));
            changeProfileItem.Click();
        }

        public static void ClickChangePasswordItem()
        {
            IWebElement profileItem = SeleniumController.Instance.Driver.FindElement(By.Id("currentuser"));
            profileItem.Click();
            IWebElement changePasswordItem = SeleniumController.Instance.Driver.FindElement(By.Id("changepassword"));
            changePasswordItem.Click();
        }

        public static void ClickSaveButton()
        {
            SeleniumController.WaitTime("button#submit");
            IWebElement saveButton = SeleniumController.Instance.Driver.FindElement(By.Id("submit"));
            saveButton.Click();
            SeleniumController.WaitTime("strong#errorMessage");
         }

 
        public static void ClickCancelButton()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("cancel"), 30);
            IWebElement cancelButton = SeleniumController.Instance.Driver.FindElement(By.Id("cancel"));
            cancelButton.Click();
        }

        public static bool IsSalutationDropdownPresent()
        {
            IWebElement salutation = SeleniumController.Instance.Driver.FindElement(By.Id("salutation"));
            if (salutation != null)
                return true;
            else
                return false;
        }

        public static bool IsFirstNameTextFieldPresent()
        {
            IWebElement firstName = SeleniumController.Instance.Driver.FindElement(By.Id("firstName"));
            if (firstName != null)
                return true;
            else
                return false;
        }

        public static bool IsLastNameTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("lastName"), 30);
            IWebElement lastName = SeleniumController.Instance.Driver.FindElement(By.Id("lastName"));
            if (lastName != null)
                return true;
            else
                return false;
        }        

        public static bool IsSuffixTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("suffix"), 30);
            IWebElement suffix = SeleniumController.Instance.Driver.FindElement(By.Id("suffix"));
            if (suffix != null)
                return true;
            else
                return false;
        }

        public static bool IsTitleTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("title"), 30);
            IWebElement title = SeleniumController.Instance.Driver.FindElement(By.Id("title"));
            if (title != null)
                return true;
            else
                return false;
        }

        public static bool IsPhoneTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("phone"), 30);
            IWebElement phone = SeleniumController.Instance.Driver.FindElement(By.Id("phone"));
            if (phone != null)
                return true;
            else
                return false;
        }

        public static bool IsCellTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("cell"), 30);
            IWebElement cell = SeleniumController.Instance.Driver.FindElement(By.Id("cell"));
            if (cell != null)
                return true;
            else
                return false;
        }

        public static bool IsAddressLine1TextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("addressLine1"), 30);
            IWebElement addressLine1 = SeleniumController.Instance.Driver.FindElement(By.Id("addressLine1"));
            if (addressLine1 != null)
                return true;
            else
                return false;
        }

        public static bool IsAddressLine2TextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("addressLine2"), 30);
            IWebElement addressLine2 = SeleniumController.Instance.Driver.FindElement(By.Id("addressLine2"));
            if (addressLine2 != null)
                return true;
            else
                return false;
        }

        public static bool IsCityTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("cityLocality"), 30);
            IWebElement city = SeleniumController.Instance.Driver.FindElement(By.Id("cityLocality"));
            if (city != null)
                return true;
            else
                return false;
        }

        public static bool IsCountryDropDowmPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("country"), 30);
            IWebElement country = SeleniumController.Instance.Driver.FindElement(By.Id("country"));
            if (country != null)
                return true;
            else
                return false;
        }

        public static bool IsStateDropDowmPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("stateProvince"), 30);
            IWebElement state = SeleniumController.Instance.Driver.FindElement(By.Id("stateProvince"));
            if (state != null)
                return true;
            else
                return false;
        }

        public static bool IsPinTextFieldPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("postalCode"), 30);
            IWebElement pin = SeleniumController.Instance.Driver.FindElement(By.Id("postalCode"));
            if (pin != null)
                return true;
            else
                return false;
        }

        public static bool IsOnDashboard()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("Technology Overview"), 30);
            IWebElement isDashboardElementPresent = SeleniumController.Instance.Driver.FindElement(By.Id("Technology Overview"));
            if (isDashboardElementPresent != null)
                return true;
            else
                return false;
        }
     
        public static bool IsOldPasswordPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("oldPassword"), 30);
            IWebElement isOldPasswordPresent = SeleniumController.Instance.Driver.FindElement(By.Id("oldPassword"));
            if (isOldPasswordPresent != null)
                return true;
            else
                return false;
        }

        public static bool IsNewPasswordPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("newPassword"), 30);
            IWebElement isNewPasswordPresent = SeleniumController.Instance.Driver.FindElement(By.Id("newPassword"));
            if (isNewPasswordPresent != null)
                return true;
            else
                return false;
        }

        public static bool IsConfirmPasswordPresent()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("confirmPassword"), 30);
            IWebElement isConfirmPasswordPresent = SeleniumController.Instance.Driver.FindElement(By.Id("confirmPassword"));
            if (isConfirmPasswordPresent != null)
                return true;
            else
                return false;
        }
     
        public static void EditFirstName()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("submit"), 30);
            IWebElement firstName = SeleniumController.Instance.Driver.FindElement(By.Id("firstName"));
            //Issue on trying to extract the initial value in the First Name Field
            _intialName = firstName.GetAttribute("Value");
            firstName.Clear();
            firstName.SendKeys("new first name");
        }


        public static void EditLastName()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("lastName"), 30);
            IWebElement lastName = SeleniumController.Instance.Driver.FindElement(By.Id("lastName"));
            lastName.Clear();
            lastName.SendKeys("new last name");
        }


        public static void AddSuffix()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("suffix"), 30);
            IWebElement suffix = SeleniumController.Instance.Driver.FindElement(By.Id("suffix"));
            suffix.Clear();
            suffix.SendKeys("suffix");
        }

        public static void AddANewPassword()
        {
            SeleniumController.WaitTime("input#newPassword");
            IWebElement newPwd = SeleniumController.Instance.Driver.FindElement(By.CssSelector("input#newPassword"));
            newPwd.Clear();
            newPwd.SendKeys("NewPassword1!");

            SeleniumController.WaitTime("input#confirmPassword");
            IWebElement confirmPwd = SeleniumController.Instance.Driver.FindElement(By.CssSelector("input#confirmPassword"));
            confirmPwd.Clear();
            confirmPwd.SendKeys("NewPassword1!");
        }

        public static void AddSameOldPassword()
        {
            SeleniumController.WaitTime("input#oldPassword");
            IWebElement oldPwd = SeleniumController.Instance.Driver.FindElement(By.CssSelector("input#oldPassword"));
            oldPwd.Clear();
            oldPwd.SendKeys("NewPassword1!");
        }

        public static void EmptyFirstName()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("firstName"), 30);
            IWebElement firstName = SeleniumController.Instance.Driver.FindElement(By.Id("firstName"));
            firstName.Clear();
        }

        public static void EmptySuffix()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("suffix"), 30);
            IWebElement suffix = SeleniumController.Instance.Driver.FindElement(By.Id("suffix"));
            suffix.Clear();
        }

        public static void EmptyOldPassword()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("oldPassword"), 30);
            IWebElement oldPassword = SeleniumController.Instance.Driver.FindElement(By.Id("oldPassword"));
            oldPassword.Clear();
        }

        public static bool IsFirstNameErrorVisible()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("requiredFName"), 30);
            IWebElement firstNameError = SeleniumController.Instance.Driver.FindElement(By.Id("requiredFName"));
            if (firstNameError != null)
                return true;
            else
                return false;
        }

        public static bool IsOldPasswordErrorVisible()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.Id("requiredOPassword"), 30);
            IWebElement oldPasswordError = SeleniumController.Instance.Driver.FindElement(By.Id("requiredOPassword"));
            if (oldPasswordError != null)
                return true;
            else
                return false;
        }

        public static bool IsSamePwdValidationPresent()
        {
            SeleniumController.WaitTime("strong#errorMessage");
            IWebElement samePasswordError = SeleniumController.Instance.Driver.FindElement(By.CssSelector("strong#errorMessage"));
            if (samePasswordError.Text == "Failed to register user: New Password can not be same as old password.")
                return true;
            else
                return false;
        }

        public static bool IsSaveSuccess()
        {
            WebDriverExtensions.WaitUntilElementIsPresent(SeleniumController.Instance.Driver, By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[2]/div[1]/strong"), 30);
            IWebElement message = SeleniumController.Instance.Driver.FindElement(By.XPath("/html/body/div/div/section/div/section/section/div/div/div/div[2]/div[1]/strong"));

            if (String.Equals("Changes saved successfully!", message.Text))
                return true;
            else
                return false;        
        }

        #region db

       /// <summary>
       /// This function confirms that the First Name is updated in the database
       /// </summary>
         public static void ConfirmUpdatedFirstName()
        {
            string connectionstring = "Data Source=localhost; Initial Catalog=ProtivitiPOC1; Integrated Security =True";
            SqlConnection Connection = new SqlConnection(connectionstring);
            Connection.Open();

            string sqluserid = "select top 1 FirstName from Registration.People order by LastChangeDate desc";
            SqlCommand comm = new SqlCommand(sqluserid, Connection);
            string text = (string)comm.ExecuteScalar();
            try
            { 
            if ("new first name" == text)
            {
                Console.Write("First Name Updated");
            }
            }
            catch(Exception)
            {
                throw;
            }

            Connection.Close();
        }

        /// <summary>
         /// This function confirms that on cancelling the changes, the First Name doesn't get updated in the database
        /// </summary>
         public static void ConfirmNoChangesOccur()
         {
             string connectionstring = "Data Source=localhost; Initial Catalog=ProtivitiPOC1; Integrated Security =True";
             SqlConnection Connection = new SqlConnection(connectionstring);
             Connection.Open();

             string sqluserid = "select FirstName from Registration.People where FirstName = '"+_intialName+"'";
             SqlCommand comm = new SqlCommand(sqluserid, Connection);
             string text = (string)comm.ExecuteScalar();
             try
             {
                 if ("Test" == text)
                 {
                     Console.Write("No changes");
                 }
             }
             catch (Exception)
             {
                 throw;
             }

             Connection.Close();
         }

        /// <summary>
        /// To Test the schema of different columns in the database. 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="len"></param>

         public static void MaxLengthOnFrontEnd(string field, string len)
         {
             _FieldName = field;
             _MaxLength = Convert.ToInt16(len);
         }

        /// <summary>
        /// This function extracts the value of Length from the database 
        /// </summary>
         public static void LengthValueInDB()
         {
             string connectionstring = "Data Source=localhost; Initial Catalog= ProtivitiPOC1; Integrated Security = True";
             SqlConnection Con = new SqlConnection(connectionstring);
             Con.Open();

             string sqlQuery = "Select CHARACTER_MAXIMUM_LENGTH from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME= 'Contacts' And COLUMN_NAME= '"+_FieldName+"'";
             SqlCommand Com = new SqlCommand(sqlQuery, Con);
             _MaxLengthDB = (int)Com.ExecuteScalar();
             
             Con.Close();
          }

        /// <summary>
        /// This function compares both the values of length(from front-end and back-end)
        /// </summary>
         public static void CompareLength()
         {
             if (_MaxLengthDB == _MaxLength)
             {
                 Console.Write("Both front end and back end has same value");
             }
             else 
             {
                 Console.Write("Issue with space utilization as max length allowed in front end is "+_MaxLength+ " but the actual space stored is "+_MaxLengthDB);
             }
         }

         public static void EnterChangedValues(string field, string value)
         {
             switch (field)
             {
                 case "Suffix":
                     IWebElement Suffix = SeleniumController.Instance.Driver.FindElement(By.Id("suffix"));
                     Suffix.Clear();
                     Suffix.SendKeys(value);
                     break;
                 case "Title":
                     IWebElement Title = SeleniumController.Instance.Driver.FindElement(By.Id("title"));
                     Title.Clear();
                     Title.SendKeys(value);
                     break;
                 case "Fax":
                     IWebElement Fax = SeleniumController.Instance.Driver.FindElement(By.Id("fax"));
                     Fax.Clear();
                     Fax.SendKeys(value);
                     break;
                 case "Address Line 2":
                     IWebElement AddressLine2 = SeleniumController.Instance.Driver.FindElement(By.Id("addressLine2"));
                     AddressLine2.Clear();
                     AddressLine2.SendKeys(value);
                     break;
                 case "Postal Code":
                     IWebElement PostalCode = SeleniumController.Instance.Driver.FindElement(By.Id("postalCode"));
                     PostalCode.Clear();
                     PostalCode.SendKeys(value);
                     break;
             }
         }

         public static void CompareValuesWithDatabase(string value, string field)
         {
             string dbvalue;
             string connectionstring = "Data Source=localhost; Initial Catalog= ProtivitiPOC1; Integrated Security = True";
             SqlConnection Con = new SqlConnection(connectionstring);
             Con.Open();
             string fieldName = field.Replace(" ", string.Empty);
             string sqlQuery = "select " +fieldName+ " from Registration.People P Join Registration.Contacts C On P.UserName = C.Email Join Registration.Addresses A On P.ContactId = A.Id where UserName='Test1@protiviti.com'";
             SqlCommand Com = new SqlCommand(sqlQuery, Con);
             dbvalue = Com.ExecuteScalar().ToString();
             try
             {
                 Assert.AreEqual(value, dbvalue);
                 Console.WriteLine("Same value is stored in the table for field - "+field);
             }
             catch (Exception e)
             {
                 Console.WriteLine("Correct value is not stored for field "+field , e);
             }

             Con.Close();
         }
        #endregion

    }
}
