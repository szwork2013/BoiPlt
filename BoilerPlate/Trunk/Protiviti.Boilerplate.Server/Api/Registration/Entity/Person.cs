using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Pattern.Ef6;

namespace Protiviti.Boilerplate.Server.Api.Registration
{
    public class Person : Entity
    {
        #region Constructor
        public Person()
        {
            //this.PersonAssignments = new List<PersonAssignment>();
            this.IsActive = true;
            //this.AddressTypeId = API.Model.Reference.BusinessEntityTypes.HomeAddress.Id;
        }
        #endregion Constructor

        #region SystemInfo
        public int Id { get; set; }

        public System.Guid UniqueId { get; set; }

        public byte[] Version { get; set; }

        #endregion SystemInfo

        #region Type

        public Nullable<int> TypeId { get; set; }

        //public virtual BusinessEntityType Type { get; set; }

        #endregion Type

        #region Properties
        [Display(
            Name = "User Name")]
        public string UserName { get; set; }

        [Display(
            Name = "Title")]
        public string Title { get; set; }

        [Display(
            Name = "Salutation")]
        public string Salutation { get; set; }

        [Display(
            Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(
            Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(
            Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(
            Name = "Suffix")]
        public string Suffix { get; set; }

        [Display(
            Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + (MiddleName != null && MiddleName != "" ? " " + MiddleName + " " : " ") + LastName;
            }
        }

        public Nullable<int> AddressId { get; set; }

        public virtual Address Address { get; set; }

        public Nullable<int> HomeAddressId { get; set; }

        public virtual Address HomeAddress { get; set; }

        public Nullable<int> ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        [Display(
             Name = "Is Active")]
        public Nullable<bool> IsActive { get; set; }

        #endregion Properties

        #region CreatedInfo
        [Display(
            Name = "Created Date")]
        public System.DateTime? CreatedDate { get; set; }

        public Nullable<int> CreatedPersonId { get; set; }

        //public virtual Person CreatedPerson { get; set; }
        #endregion CreatedInfo

        #region LastChangeInfo
        [Display(
            Name = "Last Change Date")]
        public System.DateTime? LastChangeDate { get; set; }

        public Nullable<int> LastChangePersonId { get; set; }

        //public virtual Person LastChangePerson { get; set; }

        #endregion LastChangeInfo

        #region Collection


        //public virtual ICollection<PersonAssignment> PersonAssignments { get; set; }

        #endregion Collection

        #region ILoggable

        /// <summary>
        /// Name of the entity used for logging.
        /// </summary>
        public string EntityName
        {
            get { return this.FullName; }
        }

        /// <summary>
        /// Type of the entity used for logging.
        /// </summary>
        public string EntityType
        {
            get { return "Person"; }
        }

        /// <summary>
        /// Id of the entity used for logging.
        /// </summary>
        public string EntityId
        {
            get { return this.Id.ToString(); }
        }

        /// <summary>
        /// Any special data about the announcement that should be logged with the entity.
        /// </summary>
        public string EntityData
        {
            get { return null; }
        }

        //LogEntrySignificance logSignificance = LogEntrySignificance.regularEntry;
        ///// <summary>
        ///// Sets the default significance for logging the entity.
        ///// The significance is used to filter what is logged.
        ///// </summary>
        //public LogEntrySignificance LogSignificance
        //{
        //    get
        //    {
        //        return logSignificance;
        //    }
        //    set
        //    {
        //        logSignificance = value;
        //    }
        //}

        #endregion ILoggable

        #region Method

        public Person Copy(int personId)
        {
            return new Person()
            {
                Address = this.Address.Copy(personId),
                //Contact = this.Contact.Copy(personId),
                CreatedDate = DateTime.UtcNow,
                CreatedPersonId = personId,
                FirstName = this.FirstName,
                LastChangeDate = DateTime.UtcNow,
                LastChangePersonId = personId,
                LastName = this.LastName,
                MiddleName = this.MiddleName,
                Salutation = this.Salutation,
                Suffix = this.Suffix,
                Title = this.Title,
                UniqueId = Guid.NewGuid(),
                //AssignedRoleId = this.AssignedRoleId,
                TypeId = this.TypeId,
                IsActive = this.IsActive,
                //IsFullListing = this.IsFullListing,
                //AddressTypeId = this.AddressTypeId

            };
        }

        public bool IsEqual(Person personToCheck, bool ignoreCase)
        {
            bool bSame = true;

            bSame = StringCompareIgnoreNull(this.Contact.Email, personToCheck.Contact.Email, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Contact.Phone, personToCheck.Contact.Phone, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Contact.Fax, personToCheck.Contact.Fax, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Contact.Cell, personToCheck.Contact.Cell, ignoreCase, bSame);

            bSame = StringCompareIgnoreNull(this.Address.Organization, personToCheck.Address.Organization, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Address.CityLocality, personToCheck.Address.CityLocality, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Address.AddressLine1, personToCheck.Address.AddressLine1, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Address.AddressLine2, personToCheck.Address.AddressLine2, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Address.StateProvince, personToCheck.Address.StateProvince, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Address.PostalCode, personToCheck.Address.PostalCode, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Address.Country, personToCheck.Address.Country, ignoreCase, bSame);

            bSame = StringCompareIgnoreNull(this.Salutation, personToCheck.Salutation, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.FirstName, personToCheck.FirstName, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.LastName, personToCheck.LastName, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Suffix, personToCheck.Suffix, ignoreCase, bSame);
            bSame = StringCompareIgnoreNull(this.Title, personToCheck.Title, ignoreCase, bSame);

            return bSame;
        }

        private bool StringCompareIgnoreNull(string str1, string str2, bool ignoreCase, bool bSame)
        {
            if (!bSame)
            {
                return bSame;
            }
            return string.Compare(str1 == null ? "" : str1, str2 == null ? "" : str2, ignoreCase) == 0 ? true : false;
        }

        #endregion Method
    }
}