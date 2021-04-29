using Microsoft.AspNetCore.Identity;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace Heals.CSX.Mall.Users
{
    /* This entity shares the same table/collection ("AbpUsers" by default) with the
     * IdentityUser entity of the Identity module.
     *
     * - You can define your custom properties into this class.
     * - You never create or delete this entity, because it is Identity module's job.
     * - You can query users from database with this entity.
     * - You can update values of your custom properties.
     */
    public class AppUser : IdentityUser, IUser
    {
        #region Base properties

        /* These properties are shared with the IdentityUser entity of the Identity module.
         * Do not change these properties through this class. Instead, use Identity module
         * services (like IdentityUserManager) to change them.
         * So, this properties are designed as read only!
         */
        public virtual Guid Id { get; private set; }

        public virtual Guid? TenantId { get; private set; }

        public virtual string UserName { get; private set; }

        public virtual string Name { get; private set; }

        public virtual string Surname { get; private set; }

        public virtual string Email { get; private set; }

        public virtual bool EmailConfirmed { get; private set; }

        public virtual string PhoneNumber { get; private set; }

        public virtual bool PhoneNumberConfirmed { get; private set; }

        #endregion

        /* Add your own properties here. Example:   
         *
         * public string MyProperty { get; set; }
         *
         * If you add a property and using the EF Core, remember these;
         *
         * 1. Update MallDbContext.OnModelCreating
         * to configure the mapping for your new property
         * 2. Update MallEfCoreEntityExtensionMappings to extend the IdentityUser entity
         * and add your new property to the migration.
         * 3. Use the Add-Migration to add a new database migration.
         * 4. Run the .DbMigrator project (or use the Update-Database command) to apply
         * schema change to the database.
         */

        public string ClinicCode { get; set; }
        public string DoctorCode { get; set; }
        public string PasswordText { get; set; }




        //private AppUser()
        //{
            
        //}

        protected AppUser()
        {
        }

        public AppUser(
            Guid id,
            Guid? tenantId,
            string userName,
            string name,
            string surname,
            string email,
            bool emailConfirmed,
            string phoneNumber,
            bool phoneNumberConfirmed,
            string clinicCode,
            string doctorCode,
            string passwordText
        ) : base(id.ToString())
        {
            TenantId = tenantId;
            UserName = userName;
            Name = name;
            Surname = surname;
            Email = email;
            EmailConfirmed = emailConfirmed;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumberConfirmed;
            ClinicCode = clinicCode;
            DoctorCode = doctorCode;
            PasswordText = passwordText;
        }

        object[] IEntity.GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
