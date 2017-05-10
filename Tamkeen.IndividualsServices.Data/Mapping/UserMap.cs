using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(255);

            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.SecondName)
                .HasMaxLength(50);

            this.Property(t => t.ThirdName)
                .HasMaxLength(50);

            this.Property(t => t.FourthName)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.MobileNumber)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("MOL_User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.FirstName).HasColumnName("First_Name");
            this.Property(t => t.SecondName).HasColumnName("Second_Name");
            this.Property(t => t.ThirdName).HasColumnName("Third_Name");
            this.Property(t => t.FourthName).HasColumnName("Fourth_Name");
            this.Property(t => t.NationalityId).HasColumnName("Nationality");
            this.Property(t => t.BirthDate).HasColumnName("Birth_Date");
            this.Property(t => t.TypeId).HasColumnName("User_Type_Id");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.IdNumber).HasColumnName("Id_Number");
            this.Property(t => t.IdExpiryDate).HasColumnName("Id_ExpiryDate");
            this.Property(t => t.IqamaNumber).HasColumnName("Iqama_Number");
            this.Property(t => t.IqamaExpiryDate).HasColumnName("Iqama_ExpiryDate");
            this.Property(t => t.Deleted).HasColumnName("IsUserDeleted");
            this.Property(t => t.Activated).HasColumnName("IsActivated");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.IsSystem).HasColumnName("IsSystem");
            this.Property(t => t.EmailVerified).HasColumnName("IsEmailVerified");
            this.Property(t => t.EmailVerificationCount).HasColumnName("EmailVerificationCount");
            this.Property(t => t.EmailLastVerificationDate).HasColumnName("EmailLastVerificationDate");
            this.Property(t => t.MobileVerified).HasColumnName("IsMobileVerified");
            this.Property(t => t.MobileVerificationCount).HasColumnName("MobileVerificationCount");
            this.Property(t => t.MobileLastVerificationDate).HasColumnName("MobileLastVerificationDate");
            this.Property(t => t.DataVerified).HasColumnName("IsDataVerified");

            // Relationships
            this.HasOptional(t => t.Type)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.TypeId);
            this.HasOptional(t => t.Nationality)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.NationalityId);
            this.HasOptional(t => t.LaborOffice)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.LaborOfficeId);
        }
    }
}
