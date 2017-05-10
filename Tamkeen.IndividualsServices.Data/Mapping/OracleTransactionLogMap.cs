using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class OracleTransactionLogMap : EntityTypeConfiguration<OracleTransactionLog>
    {
        public OracleTransactionLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RepresentativeIdNo)
                .HasMaxLength(50);

            this.Property(t => t.OracleResult)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MOL_OracleTransactionLog");
            this.Property(t => t.Id).HasColumnName("PK_OracleTransactionId");
            this.Property(t => t.OnlineRequestsId).HasColumnName("FK_Online_Requests");
            this.Property(t => t.ServiceId).HasColumnName("FK_ServiceId");
            this.Property(t => t.UserId).HasColumnName("FK_UserId");
            this.Property(t => t.LabOff).HasColumnName("Lab_Off");
            this.Property(t => t.SerYY).HasColumnName("Ser_YY");
            this.Property(t => t.SeqNo).HasColumnName("Seq_No");
            this.Property(t => t.EstablishmentId).HasColumnName("FK_EstablishmentId");
            this.Property(t => t.RepresentativeIdNo).HasColumnName("RepresentativeIdNo");
            this.Property(t => t.TransactionStatus).HasColumnName("TransactionStatus");
            this.Property(t => t.OracleResult).HasColumnName("OracleResult");
            this.Property(t => t.Error).HasColumnName("Error");
            this.Property(t => t.ManPower).HasColumnName("isManPower");
            this.Property(t => t.TimeStamp).HasColumnName("TimeStamp");

            // Relationships
            this.HasRequired(t => t.Service)
                .WithMany(t => t.OracleTransactionLogs)
                .HasForeignKey(d => d.ServiceId);
            this.HasRequired(t => t.Establishment)
                .WithMany(t => t.OracleTransactionLogs)
                .HasForeignKey(d => d.EstablishmentId);
            //this.HasRequired(t => t.CJD_Online_Requests)
            //    .WithMany(t => t.MOL_OracleTransactionLog)
            //    .HasForeignKey(d => d.FK_Online_Requests);
            this.HasOptional(t => t.User)
                .WithMany(t => t.OracleTransactionLogs)
                .HasForeignKey(d => d.UserId);
        }
    }
}
