using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
