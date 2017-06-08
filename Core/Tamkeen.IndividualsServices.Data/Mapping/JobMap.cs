using Tamkeen.IndividualsServices.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.JobCode)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Lookup_Job");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IsForSaudiOnly).HasColumnName("IsForSaudiOnly");
            this.Property(t => t.JobCode).HasColumnName("JobCode");

        }
    }
}
