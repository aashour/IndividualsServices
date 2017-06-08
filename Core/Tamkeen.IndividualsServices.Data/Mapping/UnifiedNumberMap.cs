using Tamkeen.IndividualsServices.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class UnifiedNumberMap : EntityTypeConfiguration<UnifiedNumber>
    {
        public UnifiedNumberMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("MOL_UnifiedNumber");
            this.Property(t => t.Id).HasColumnName("PK_UnifiedNumberId");
            this.Property(t => t.LaborOfficeId).HasColumnName("FK_LaborOfficeId");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.TypeId).HasColumnName("FK_EstablishmentTypeId");
            this.Property(t => t.SevenHundredNumber).HasColumnName("SevenHundredNumber");
            this.Property(t => t.OwnerId).HasColumnName("FK_OwnerId");

            // Relationships
            this.HasOptional(t => t.Type)
                .WithMany(t => t.UnifiedNumbers)
                .HasForeignKey(d => d.TypeId);

            this.HasRequired(t => t.LaborOffice)
                            .WithMany(t => t.UnifiedNumbers)
                            .HasForeignKey(d => d.LaborOfficeId);

            this.HasOptional(t => t.Owner)
                .WithMany(t => t.UnifiedNumbers)
                .HasForeignKey(d => d.OwnerId);


        }
    }
}
