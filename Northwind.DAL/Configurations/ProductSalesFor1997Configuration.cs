﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Configurations
{
    internal class ProductSalesFor1997Configuration : IEntityTypeConfiguration<ProductSalesFor1997>
    {
        public void Configure(EntityTypeBuilder<ProductSalesFor1997> entity)
        {
            entity.HasNoKey();

            entity.ToView("Product Sales for 1997");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ProductSales).HasColumnType("money");
        }

    }
}
