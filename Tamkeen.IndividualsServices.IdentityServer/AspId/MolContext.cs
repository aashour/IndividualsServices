using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;

namespace Tamkeen.IndividualServices.IdentityServer.AspId
{
    public class MolContext : IdentityDbContext<MolUser, MolRole, int, MolUserLogin, MolUserRole, MolUserClaim>
    {
        public MolContext(string connString)
            : base(connString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<MolUser>();
            user.ToTable("MOL_User");
            user.Property(x => x.PasswordHash).HasColumnName("Password");
            user.Property(x => x.FirstName).HasColumnName("First_Name");
            user.Property(x => x.SecondName).HasColumnName("Second_Name");
            user.Property(x => x.ThirdName).HasColumnName("Third_Name");
            user.Property(x => x.FourthName).HasColumnName("Fourth_Name");
            user.Property(x => x.BirthDate).HasColumnName("Birth_Date");
            user.Property(x => x.UserTypeId).HasColumnName("User_Type_Id");
            user.Property(x => x.IdNumber).HasColumnName("Id_Number");
            user.Property(x => x.IdExpiryDate).HasColumnName("Id_Expiry_Date");
            user.Property(x => x.IqamaNumber).HasColumnName("Iqama_Number");
            user.Property(x => x.IqamaExpiryDate).HasColumnName("Iqama_Expiry_Date");

            var role = modelBuilder.Entity<MolRole>();
            role.ToTable("MOL_Role");
        }
    }
}