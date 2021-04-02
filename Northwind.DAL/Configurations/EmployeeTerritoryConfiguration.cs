﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Configurations
{
    internal class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritory> entity)
        {
            entity.HasKey(e => new { e.EmployeeId, e.TerritoryId })
                .IsClustered(false);

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Employees");

            entity.HasOne(d => d.Territory)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Territories");
        }

    }
}
