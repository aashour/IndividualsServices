﻿using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data.Mapping
{
    public class NationalityMap : EntityTypeConfiguration<Nationality>
    {
        public NationalityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NameEN)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Lookup_Nationality");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NameEN).HasColumnName("Name_EN");
            this.Property(t => t.IsIncludedForEWV).HasColumnName("IsIncludedForEWV");
        }
    }
}
