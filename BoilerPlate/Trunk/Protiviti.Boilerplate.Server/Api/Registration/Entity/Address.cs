using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Protiviti.Boilerplate.Server.Api.Registration
{
    [DebuggerDisplay("{AddressLine1}")]
    public class Address 
    {
        #region System Info
        
        public int Id { get; set; }

        public System.Guid UniqueId { get; set; }

        public byte[] Version { get; set; }

        #endregion System Info

        #region Address Fields

        public string Organization { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string CityLocality { get; set; }

        public string StateProvince { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Attention { get; set; }

        public string PONumber { get; set; }

        #endregion Address Fields

        #region Geography

        public decimal? Latitude { get; set; }
       
        public decimal? Longitude { get; set; }

        #endregion Geography

        #region MetaDataa

        public Nullable<bool> Duplicate { get; set; }

        public Nullable<bool> Verified { get; set; }

        #endregion MetaData

        

        #region Created

        public System.DateTime? CreatedDate { get; set; }

        public int? CreatedPersonId { get; set; }

        #endregion Created

        #region Last Change

        public System.DateTime? LastChangeDate { get; set; }
                
        public int? LastChangePersonId { get; set; }

        #endregion Last Change
        
        #region Methods

        public void Copy(Address sourceAddress, bool needUniqueId, bool needPersonInfo)
        {
            AddressLine1 = sourceAddress.AddressLine1;
            AddressLine2 = sourceAddress.AddressLine2;
            CityLocality = sourceAddress.CityLocality;
            Country = sourceAddress.Country;
            Organization = sourceAddress.Organization;
            PostalCode = sourceAddress.PostalCode;
            StateProvince = sourceAddress.StateProvince;
            PONumber = sourceAddress.PONumber;
            Verified = sourceAddress.Verified;
            Longitude = sourceAddress.Longitude;
            Latitude = sourceAddress.Latitude;
            Attention = sourceAddress.Attention;
            SiteNumber = sourceAddress.SiteNumber;
            if (needUniqueId)
            {
                UniqueId = sourceAddress.UniqueId;
            }
            if (needPersonInfo)
            {
                CreatedDate = sourceAddress.CreatedDate;
                CreatedPersonId = sourceAddress.CreatedPersonId;
                LastChangeDate = sourceAddress.LastChangeDate;
                LastChangePersonId = sourceAddress.LastChangePersonId;
            }
        }
        public Address Copy(int personId)
        {
            return new Address()
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                CityLocality = CityLocality,
                Country = Country,
                CreatedDate = DateTime.UtcNow,
                CreatedPersonId = personId,
                LastChangeDate = DateTime.UtcNow,
                LastChangePersonId = personId,
                Organization = Organization,
                PostalCode = PostalCode,
                StateProvince = StateProvince,
                PONumber = PONumber,
                SiteNumber = SiteNumber,
                UniqueId = Guid.NewGuid(),
                Verified = Verified,
                Longitude = Longitude,
                Latitude = Latitude,
                Attention = Attention
            };
        }
        public void Copy(Address verifiedAddress, int personId)
        {
            this.AddressLine1 = string.IsNullOrEmpty(verifiedAddress.AddressLine1) ? this.AddressLine1 : verifiedAddress.AddressLine1; // this is because AddressLine 1 is required
            this.AddressLine2 = verifiedAddress.AddressLine2;
            this.CityLocality = string.IsNullOrEmpty(verifiedAddress.CityLocality) ? this.CityLocality : verifiedAddress.CityLocality; // this is because CityLocality is required
            this.StateProvince = verifiedAddress.StateProvince;
            this.Country = verifiedAddress.Country;
            this.PostalCode = verifiedAddress.PostalCode;
            this.SiteNumber = verifiedAddress.SiteNumber;
            this.Verified = verifiedAddress.Verified;
            if (personId > 0)
            {
                this.LastChangeDate = DateTime.UtcNow;
                this.LastChangePersonId = personId;
            }
        }

        public bool IsAboutEqual(Address address, bool ignoreCase)
        {
            if (String.Compare(this.AddressLine1, address.AddressLine1, ignoreCase) != 0)
                return false;
            if (String.Compare(this.AddressLine2 == null ? "" : this.AddressLine2, address.AddressLine2 == null ? "" : address.AddressLine2, ignoreCase) != 0)
                return false;
            if (String.Compare(this.CityLocality, address.CityLocality, ignoreCase) != 0)
                return false;
            if (String.Compare(this.StateProvince, address.StateProvince, ignoreCase) != 0)
                return false;
            if (String.Compare(this.Country, address.Country, ignoreCase) != 0)
                return false;
            return true;
        }

        #endregion Methods

        #region State Provice Codes

        public Dictionary<string, string> StateProvinceCodes
        {
            get
            {
                return dictionaryStateProvinceCode;
            }
        }

        private static Dictionary<string, string> dictionaryStateProvinceCode = new Dictionary<string, string>()
        {
                /// US State codes
                /// 
                {"",""}, // This forces the user to select an option
                {"Alabama, US","AL"},
                {"Alaska, US","AK"},
                {"Arizona, US","AZ"},
                {"Arkansas, US","AR"},
                {"Armed Forces America","AA"},
                {"Armed Forces Europe","AE"},
                {"Armed Forces Pacific","AP"},
                {"California, US","CA"},
                {"Colorado, US","CO"},
                {"Connecticut, US","CT"},
                {"Delaware, US","DE"},
                {"District of Columbia, US","DC"},
                {"Florida, US","FL"},
                {"Georgia, US","GA"},
                {"Hawaii, US","HI"},
                {"Idaho, US","ID"},
                {"Illinois, US","IL"},
                {"Indiana, US","IN"},
                {"Iowa, US","IA"},
                {"Kansas, US","KS"},
                {"Kentucky, US","KY"},
                {"Louisiana, US","LA"},
                {"Maine, US","ME"},
                {"Maryland, US","MD"},
                {"Massachusetts, US","MA"},
                {"Michigan, US","MI"},
                {"Minnesota, US","MN"},
                {"Mississippi, US","MS"},
                {"Missouri, US","MO"},
                {"Montana, US","MT"},
                {"Nebraska, US","NE"},
                {"Nevada, US","NV"},
                {"New Hampshire, US","NH"},
                {"New Jersey, US","NJ"},
                {"New Mexico, US","NM"},
                {"New York, US","NY"},
                {"North Carolina, US","NC"},
                {"North Dakota, US","ND"},
                {"Ohio, US","OH"},
                {"Oklahoma, US","OK"},
                {"Oregon, US","OR"},
                {"Pennsylvania, US","PA"},
                {"Rhode Island, US","RI"},
                {"South Carolina, US","SC"},
                {"South Dakota, US","SD"},
                {"Tennessee, US","TN"},
                {"Texas, US","TX"},
                {"Utah, US","UT"},
                {"Vermont, US","VT"},
                {"Virginia, US","VA"},
                {"Washington, US","WA"},
                {"West Virginia, US","WV"},
                {"Wisconsin, US","WI"},
                {"Wyoming, US","WY"},
 
                // Canadian Province codes
                {"Alberta, CA","AB"},
                {"British Columbia, CA","BC"},
                {"Manitoba, CA","MB"},
                {"New Brunswick, CA","NB"},
                {"Newfoundland and Labrador, CA","NL"},
                {"Northwest Territories, CA","NT"},
                {"Nova Scotia, CA","NS"},
                {"Nunavut, CA","NU"},
                {"Ontario, CA","ON"},
                {"Prince Edward Island, CA","PE"},
                {"Quebec, CA","QC"},
                {"Saskatchewan, CA","SK"},
                {"Yukon, CA","YT"}
 
        };

        #endregion State Provice Codes

        
        public Nullable<int> SiteNumber { get; set; }
    }
}
