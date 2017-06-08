using Tamkeen.IndividualsServices.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class EstablishmentMap : EntityTypeConfiguration<Establishment>
    {
        public EstablishmentMap()
        {
            this.ToTable("MOL_Establishment");
            this.HasKey(est => est.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.Id).HasColumnName("PK_EstablishmentId");
            this.Property(t => t.UnifiedNumberId).HasColumnName("FK_UnifiedNumberId");
            this.Property(t => t.LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CommercialRecordNumber).HasColumnName("CommercialRecordNumber");
            this.Property(t => t.StatusId).HasColumnName("FK_EstablishmentStatusId");
            this.Property(t => t.MainEconomicActivityId).HasColumnName("FK_MainEconomicActivityId");
            this.Property(t => t.SubEconomicActivityId).HasColumnName("FK_SubEconomicActivityId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Wasel.Status).HasColumnName("WASELStatus");
            this.Property(t => t.Wasel.ZipCode).HasColumnName("WASELZipCode");
            this.Property(t => t.Wasel.Primary).HasColumnName("WASELPrimary");
            this.Property(t => t.Wasel.Secondary).HasColumnName("WASELSecondary");
            this.Property(t => t.Wasel.UnitNo).HasColumnName("WASELUnitNo");
            this.Property(t => t.Wasel.City).HasColumnName("WASELCity");
            this.Property(t => t.Wasel.Area).HasColumnName("WASELArea");
            this.Property(t => t.Wasel.Street).HasColumnName("WASELStreet");
            this.Property(t => t.Wasel.ExpiryDate).HasColumnName("WASELExpiryDate");

            // Relationships
            this.HasOptional(t => t.Status)
                .WithMany(t => t.Establishments)
                .HasForeignKey(d => d.StatusId);

            this.HasRequired(t => t.UnifiedNumber)
                .WithMany(t => t.Establishments)
                .HasForeignKey(d => d.UnifiedNumberId);

            this.HasRequired(t => t.LaborOffice)
                .WithMany(t => t.Establishments)
                .HasForeignKey(d => d.LaborOfficeId);

            this.HasOptional(t => t.MainEconomicActivity)
                .WithMany(t => t.EstablishmentByMainEconomicActivity)
                .HasForeignKey(d => d.MainEconomicActivityId);

            this.HasOptional(t => t.SubEconomicActivity)
               .WithMany(t => t.EstablishmentBySubEconomicActivity)
               .HasForeignKey(d => d.SubEconomicActivityId);
        }
    }
}