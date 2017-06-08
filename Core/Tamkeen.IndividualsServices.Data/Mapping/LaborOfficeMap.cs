using Tamkeen.IndividualsServices.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class LaborOfficeMap : EntityTypeConfiguration<LaborOffice>
    {
        public LaborOfficeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(40);
            // Table & Column Mappings
            this.ToTable("MOL_LaborOffice");
            this.Property(t => t.Id).HasColumnName("PK_LaborOfficeId");
            this.Property(t => t.Name).HasColumnName("Name");
            // Relationships
        }
    }
}
