using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class ServiceLogMap : EntityTypeConfiguration<ServiceLog>
    {
        public ServiceLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            // Table & Column Mappings
            this.ToTable("MOL_Service_Log");
            this.Property(t => t.Id).HasColumnName("LogID");
            this.Property(t => t.ServiceId).HasColumnName("ServiceID");
            this.Property(t => t.EstablishmentId).HasColumnName("FK_EstablishmentID");
            this.Property(t => t.LaborerId).HasColumnName("FK_LaborerID");
            this.Property(t => t.UserId).HasColumnName("CreatedByUserID");

            this.HasRequired(t => t.Requester)
                .WithMany(t => t.ServiceLogs)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.Service)
                .WithMany(t => t.ServiceLogs)
                .HasForeignKey(d => d.ServiceId);

            this.HasRequired(t => t.Laborer)
                .WithMany(t => t.ServiceLogs)
                .HasForeignKey(d => d.LaborerId);

            this.HasRequired(t => t.Establishment)
                .WithMany(t => t.ServiceLogs)
                .HasForeignKey(d => d.EstablishmentId);
        }
    }
}
