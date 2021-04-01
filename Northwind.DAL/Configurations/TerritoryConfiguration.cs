﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Configurations
{
    internal class TerritoryConfiguration : IEntityTypeConfiguration<Territory>
    {
        public void Configure(EntityTypeBuilder<Territory> entity)
        {
            entity.HasKey(e => e.TerritoryId)
                .IsClustered(false);

            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");

            entity.Property(e => e.RegionId).HasColumnName("RegionID");

            entity.Property(e => e.TerritoryDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength(true);

            entity.HasOne(d => d.Region)
                .WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        }
    }

}

