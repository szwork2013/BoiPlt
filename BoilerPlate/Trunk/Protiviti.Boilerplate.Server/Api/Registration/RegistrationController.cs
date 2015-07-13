using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using Breeze.ContextProvider;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;
using Protiviti.Boilerplate.Server.Api.Registration;
using Protiviti.Boilerplate.Server.Logging;
using System.Data.Linq;
using System.Data.Entity;
using System.Data;
using Breeze.ContextProvider.EF6;
using Protiviti.Boilerplate.Server.Api.Account;

namespace Protiviti.Boilerplate.Server.Api.Registration
{
    [SlabLoggingFilter]
    [BreezeController]
    [RoutePrefix("api/registration")]
    public class RegistrationController : BaseController
    {
        #region DB Context

        //private RegistrationDbContext dbContext = new RegistrationDbContext();

        private EFContextProvider<RegistrationDbContext> _contextProvider = new EFContextProvider<RegistrationDbContext>();

        #endregion

        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize(Roles = IdentityConstants.Roles.Administrator)]
        public IQueryable<Person> People()
        {
            return _contextProvider.Context.People.Include(x => x.Contact).Include(x => x.Address).Where(p => p.UserName != IdentityConstants.AdminEmail);
            //var registeredUsers = UnitOfWorkAsync.RepositoryAsync<Person>();
            //return registeredUsers.Queryable();
        }

        [HttpGet]
        [Route("Metadata")]
        public async Task<string> Metadata()
        {
            return await UnitOfWorkAsync.MetaData();
        }

        [HttpPost]
        [Route("SaveChanges")]
        public Task<SaveResult> SaveChanges(JObject saveBundle)
        {
            try
            {
                return UnitOfWorkAsync.SaveChangesAsync(saveBundle);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("UpdateUserProfile")]
        public bool UpdateUserProfile(Person updatedPerson)
        {
            try
            {
                var regContext = new RegistrationDbContext();

                //get existing person
                var person = _contextProvider.Context.People.Include(x => x.Contact).Include(x=> x.Address).SingleOrDefault(p => p.Id == updatedPerson.Id);

                #region update meta data properties
                person.LastChangeDate = DateTime.UtcNow;
                person.Address.LastChangeDate = DateTime.UtcNow;
                if (person.HomeAddress != null)
                    person.HomeAddress.LastChangeDate = DateTime.UtcNow;
                person.Contact.LastChangeDate = DateTime.UtcNow;
                person.LastChangePersonId = person.Id;
                person.Address.LastChangePersonId = person.Id;
                if (person.HomeAddress != null)
                   person.HomeAddress.LastChangePersonId = person.Id;
                person.Contact.LastChangePersonId = person.Id;
                #endregion  

                #region update person details
                person.Salutation = updatedPerson.Salutation;
                person.FirstName = updatedPerson.FirstName;
                person.LastName = updatedPerson.LastName;
                person.MiddleName = updatedPerson.MiddleName;
                person.Suffix = updatedPerson.Suffix;
                person.Title = updatedPerson.Title;

                person.Contact.Phone = updatedPerson.Contact.Phone;
                person.Contact.Fax = updatedPerson.Contact.Fax;
                person.Contact.Cell = updatedPerson.Contact.Cell;

                person.Address.AddressLine1 = updatedPerson.Address.AddressLine1;
                person.Address.AddressLine2 = updatedPerson.Address.AddressLine2;
                person.Address.CityLocality = updatedPerson.Address.CityLocality;
                person.Address.StateProvince = updatedPerson.Address.StateProvince;
                person.Address.Country = updatedPerson.Address.Country;
                person.Address.PostalCode = updatedPerson.Address.PostalCode;

                #endregion 

                regContext.People.Attach((person));
                regContext.Entry(person).State = System.Data.Entity.EntityState.Modified;

                if (person.Address != null)
                    regContext.Entry(person.Address).State = System.Data.Entity.EntityState.Modified;
                if (person.HomeAddress != null)
                    regContext.Entry(person.HomeAddress).State = System.Data.Entity.EntityState.Modified;
                if (person.Contact != null)
                    regContext.Entry(person.Contact).State = System.Data.Entity.EntityState.Modified;
                regContext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("GetPersonByEmailId/{emailId}")]
        public Person GetPerson(string emailId)
        {
            try
            {
                var person = _contextProvider.Context.People.Include(x => x.Contact).SingleOrDefault(p => p.Contact.Email == emailId);
                return person;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("GetPersonByUserName")]
        public Person GetPerson()
        {
            try
            {
                var userName = User.Identity.Name;
                var person = _contextProvider.Context.People.Include(x => x.Contact).SingleOrDefault(p => p.Contact.Email == userName);
                person.Address = _contextProvider.Context.Addresses.SingleOrDefault(a => a.Id == person.Id);
                
                return person;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Inserts a new record inot the People table
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool CreatePerson(Person person)
        {
            try
            {

                #region Setup metadata properties

                //Set meta data properties.
                person.UniqueId = Guid.NewGuid();
                person.CreatedDate = DateTime.UtcNow;
                person.LastChangeDate = DateTime.UtcNow;

                person.Address.UniqueId = Guid.NewGuid();
                person.Address.CreatedDate = DateTime.UtcNow;
                person.Address.LastChangeDate = DateTime.UtcNow;

                if (person.HomeAddress != null)
                {
                    person.HomeAddress.UniqueId = Guid.NewGuid();
                    person.HomeAddress.CreatedDate = DateTime.UtcNow;
                    person.HomeAddress.LastChangeDate = DateTime.UtcNow;
                }

                person.Contact.UniqueId = Guid.NewGuid();
                person.Contact.CreatedDate = DateTime.UtcNow;
                person.Contact.LastChangeDate = DateTime.UtcNow;

                //Temporarily set unknown values.
                person.Address.CreatedPersonId = 1;
                person.Address.LastChangePersonId = 1;
                if (person.HomeAddress != null)
                {
                    person.HomeAddress.CreatedPersonId = 1;
                    person.HomeAddress.LastChangePersonId = 1;
                }
                person.Contact.CreatedPersonId = 1;
                person.Contact.LastChangePersonId = 1;

                #endregion

                var regContext = new RegistrationDbContext();
                regContext.People.Add((person));
                regContext.SaveChanges();

                #region Update Model

                person.ContactId = person.Contact.Id;
                person.AddressId = person.Address.Id;
                if (person.HomeAddress != null)
                {
                    person.HomeAddressId = person.HomeAddress.Id;
                }

                //Update the person record with the correct created and last change person Ids.
                person.CreatedPersonId = person.Id;
                person.LastChangePersonId = person.Id;
                person.Address.CreatedPersonId = person.Id;
                person.Address.LastChangePersonId = person.Id;
                if (person.HomeAddress != null)
                {
                    person.HomeAddress.CreatedPersonId = person.Id;
                    person.HomeAddress.LastChangePersonId = person.Id;
                }
                person.Contact.CreatedPersonId = person.Id;
                person.Contact.LastChangePersonId = person.Id;

                #endregion

                regContext.People.Attach((person));
                regContext.Entry(person).State = System.Data.Entity.EntityState.Modified;

                if (person.Address != null)
                    regContext.Entry(person.Address).State = System.Data.Entity.EntityState.Modified;
                if (person.HomeAddress != null)
                    regContext.Entry(person.HomeAddress).State = System.Data.Entity.EntityState.Modified;
                if (person.Contact != null)
                    regContext.Entry(person.Contact).State = System.Data.Entity.EntityState.Modified;
                regContext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsDuplicateEmail(string emailId)
        {
            return _contextProvider.Context.People.Include(x => x.Contact).Any(x => x.Contact.Email == emailId);
        }


        #region Helper M

        #endregion
    }
}