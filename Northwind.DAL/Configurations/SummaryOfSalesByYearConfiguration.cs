﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Configurations
{
    internal class SummaryOfSalesByYearConfiguration : IEntityTypeConfiguration<SummaryOfSalesByYear>
    {
        public void Configure(EntityTypeBuilder<SummaryOfSalesByYear> entity)
        {
            entity.HasNoKey();

            entity.ToView("Summary of Sales by Year");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.Property(e => e.Subtotal).HasColumnType("money");

        }

    }
}
