﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Configurations
{
    internal class OrderSubtotalConfiguration : IEntityTypeConfiguration<OrderSubtotal>
    {
        public void Configure(EntityTypeBuilder<OrderSubtotal> entity)
        {
            entity.HasNoKey();

            entity.ToView("Order Subtotals");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.Subtotal).HasColumnType("money");
        }

    }
}
