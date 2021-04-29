using Heals.CSX.Mall.AppUsers;
using Heals.CSX.Mall.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace Heals.CSX.Mall.Web
{
    public class MallIdentityContext : IdentityDbContext<MallUser, MallRole, Guid>
    {
        public MallIdentityContext(DbContextOptions<MallIdentityContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MallUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                //b.ConfigureByConvention();
                //b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the MallEfCoreEntityExtensionMappings class
                 */
                builder.Entity<MallUser>(b =>
                {
                    b.Property(x => x.ClinicCode).IsRequired().HasMaxLength(AppUserConsts.MaxClinicCodeLength).HasColumnName(nameof(AppUser.ClinicCode));
                    b.Property(x => x.DoctorCode).IsRequired().HasMaxLength(AppUserConsts.MaxDoctorCodeLength).HasColumnName(nameof(AppUser.DoctorCode));
                    b.Property(x => x.PasswordText).IsRequired(false).HasMaxLength(AppUserConsts.MaxPasswordTextLength).HasColumnName(nameof(AppUser.PasswordText));
                });
            });

            builder.Entity<MallRole>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Roles");
            });

            builder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "UserClaims");
            });

            builder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "UserLogins");
            });

            builder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "UserTokens");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "RoleClaims");
            });

            builder.Entity<IdentityUserRole<Guid>>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "UserRoles");
            });
        }

    }
}
