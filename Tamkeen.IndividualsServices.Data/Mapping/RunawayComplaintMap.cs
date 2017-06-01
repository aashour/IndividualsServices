using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class RunawayComplaintMap : EntityTypeConfiguration<RunawayComplaint>
    {
        public RunawayComplaintMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            // Table & Column Mappings
            this.ToTable("MOL_RunAwayComplaints");
            this.Property(t => t.Id).HasColumnName("ComplaintID");
            this.Property(t => t.ClientIPAddress).HasColumnName("ClientIPAddress")
                .HasMaxLength(50);
            this.Property(t => t.ComplaintDate).HasColumnName("ComplaintDate");
            this.Property(t => t.ComplaintSequence).HasColumnName("ComplaintSequence");
            this.Property(t => t.CreatedByUserId).HasColumnName("CreatedByUserId");
            this.Property(t => t.DecidedByUserId).HasColumnName("DecidedByUserId");
            this.Property(t => t.DecisionDate).HasColumnName("DecisionDate");
            this.Property(t => t.EstablishmentId).HasColumnName("FKEstablishmentID");
            this.Property(t => t.NoteEndDate).HasColumnName("NoteEndDate");
            this.Property(t => t.RejectReason).HasColumnName("RejectReason");
            this.Property(t => t.RunawayLaborId).HasColumnName("RunawayLaborId");
            this.Property(t => t.RunawayRequestId).HasColumnName("RunawayRequestId");
            this.Property(t => t.StatusId).HasColumnName("Status");
            this.Property(t => t.Reason).HasColumnName("Reason")
                .HasMaxLength(500);

            this.HasRequired(t => t.RunawayRequest)
                .WithMany(t => t.RunawayComplaints)
                .HasForeignKey(d => d.RunawayRequestId);

            this.HasRequired(t => t.Establishment)
                .WithMany(t => t.RunawayComplaints)
                .HasForeignKey(d => d.EstablishmentId);
        }
    }
}
