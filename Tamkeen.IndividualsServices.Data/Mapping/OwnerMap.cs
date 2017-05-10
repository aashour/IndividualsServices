using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class OwnerMap : EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.IdNo)
                .HasMaxLength(15);


            // Table & Column Mappings
            this.ToTable("MOL_Owner");
            this.Property(t => t.Id).HasColumnName("PK_OwnerId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IdNo).HasColumnName("IdNo");
            this.Property(t => t.IdExpiryDate).HasColumnName("IdExpiryDate");

            // Relationships

        }
    }
}
