﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Configurations
{
    internal class QuarterlyOrderConfiguration : IEntityTypeConfiguration<QuarterlyOrder>
    {
        public void Configure(EntityTypeBuilder<QuarterlyOrder> entity)
        {

            entity.HasNoKey();

            entity.ToView("Quarterly Orders");

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.CompanyName).HasMaxLength(40);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.CustomerId)
                        .HasMaxLength(5)
                        .HasColumnName("CustomerID")
                        .IsFixedLength(true);
        }

    }
}
