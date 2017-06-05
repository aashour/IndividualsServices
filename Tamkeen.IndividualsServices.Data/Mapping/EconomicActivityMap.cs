using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class EconomicActivityMap : EntityTypeConfiguration<EconomicActivity>
    {
        public EconomicActivityMap()
        {
            this.ToTable("Lookup_EconomicActivity");
            this.HasKey(e => e.Id);

            // Properties
            this.Property(t => t.ActivityName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Id).HasColumnName("PK_EconomicActivityId");
            this.Property(t => t.ActivityName).HasColumnName("ActivityName");           

        }
    }
}
