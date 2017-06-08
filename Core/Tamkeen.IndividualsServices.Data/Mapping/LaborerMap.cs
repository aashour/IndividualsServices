using Tamkeen.IndividualsServices.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class LaborerMap : EntityTypeConfiguration<Laborer>
    {
        public LaborerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SecondName)
                .HasMaxLength(50);

            this.Property(t => t.ThirdName)
                .HasMaxLength(50);

            this.Property(t => t.FourthName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IdNo)
                .HasMaxLength(15);

            this.Property(t => t.BorderNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_Laborer");
            this.Property(t => t.Id).HasColumnName("PK_LaborerId");
            this.Property(t => t.LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SaudiFlagId).HasColumnName("FK_SaudiFlagId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.SecondName).HasColumnName("SecondName");
            this.Property(t => t.ThirdName).HasColumnName("ThirdName");
            this.Property(t => t.FourthName).HasColumnName("FourthName");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.TypeId).HasColumnName("FK_LaborerTypeId");
            this.Property(t => t.NationalityId).HasColumnName("FK_NationalityId");
            this.Property(t => t.JobId).HasColumnName("FK_JobId");
            this.Property(t => t.EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.StatusId).HasColumnName("FK_LaborerStatusId");
            this.Property(t => t.BorderNo).HasColumnName("BorderNo");
            this.Property(t => t.YearOfBirth).HasColumnName("YearOfBirth");
            this.Property(t => t.GenderId).HasColumnName("FK_GenderId");
            this.Property(t => t.LastWPExpirationDate).HasColumnName("LastWPExpirationDate");
            this.Property(t => t.PassportNo).HasColumnName("PassportNo");
            this.Property(t => t.ServiceStartDate).HasColumnName("ServiceStartDate");
            this.Property(t => t.ServiceEndDate).HasColumnName("ServiceEndDate");
            this.Property(t => t.LaborerStatusModificationDate).HasColumnName("LaborerStatusModificationDate");

            // Relationships
            this.HasRequired(t => t.Gender)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.GenderId);
            this.HasOptional(t => t.Status)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.StatusId);

            this.HasOptional(t => t.Type)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.TypeId);

            this.HasRequired(t => t.SaudiFlag)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.SaudiFlagId);

            this.HasRequired(t => t.Nationality)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.NationalityId);

            this.HasRequired(t => t.Establishment)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.EstablishmentId);

            this.HasRequired(t => t.LaborOffice)
                .WithMany(t => t.Laborers)
                .HasForeignKey(d => d.LaborOfficeId);

            this.HasRequired(t => t.Job)
                .WithMany(t => t.Laborers)
                .HasForeignKey(t => t.JobId);
        }
    }
}
