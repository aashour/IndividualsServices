using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}