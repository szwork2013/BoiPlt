using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Protiviti.Boilerplate.Server.Api.Registration
{
    public class Contact
    {
        #region Constructor

        public Contact()
        {
            this.PhoneType = "";
        }

        #endregion Constructor

        #region System Info

        public int Id { get; set; }

        public System.Guid UniqueId { get; set; }

        public byte[] Version { get; set; }

        #endregion System Info

        #region Contact Fields

        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public string Fax { get; set; }

        [StringLength(15)]
        public string Cell { get; set; }

        public string PhoneCountryCode { get; set; }

        public string PhoneExt { get; set; }

        public string FaxCountryCode { get; set; }

        public string FaxExt { get; set; }

        public string CellCountryCode { get; set; }

        public string URL { get; set; }

        public string PhoneType { get; set; }

        public string AlternatePhone { get; set; }

        public string AlternatePhoneType { get; set; }

        public string SecondaryEmail { get; set; }

        public string CCEmail { get; set; }

        public DateTime? Birthday { get; set; }

        public string PrimaryLanguage { get; set; }

        #endregion Contact Fields

        #region Created
        public System.DateTime? CreatedDate { get; set; }

        public int? CreatedPersonId { get; set; }

        #endregion Created

        #region Last Change

        public System.DateTime? LastChangeDate { get; set; }

        public int? LastChangePersonId { get; set; }

        #endregion Last Change

        #region Copy

        public Contact Copy(int personId)
        {
            return new Contact()
            {
                Cell = Cell,
                CreatedDate = DateTime.UtcNow,
                CreatedPersonId = personId,
                Email = Email,
                Fax = Fax,
                LastChangeDate = DateTime.UtcNow,
                LastChangePersonId = personId,
                Phone = Phone,
                UniqueId = Guid.NewGuid(),
                URL = URL,
                SecondaryEmail = SecondaryEmail,
                CCEmail = CCEmail,
                Birthday = Birthday,
                PhoneType = PhoneType,
                PhoneExt = PhoneExt,
                AlternatePhone = AlternatePhone,
                AlternatePhoneType = AlternatePhoneType,
                FaxExt = FaxExt,
                PrimaryLanguage = PrimaryLanguage
            };
        }

        #endregion Copy

        #region PhoneTypes
        public Dictionary<string, string> PhoneTypes
        {
            get
            {
                return dictionaryPhoneTypes;
            }
        }
        private static Dictionary<string, string> dictionaryPhoneTypes = new Dictionary<string, string>()
         {
            {"",""},
            {"Cell", "Cell"},
            {"Home", "Home"},
            {"Work", "Work"},
            {"Other", "Other"}
         };

        #endregion
    }
}
