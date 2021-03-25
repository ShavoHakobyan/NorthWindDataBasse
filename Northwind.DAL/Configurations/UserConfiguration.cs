using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.DAL.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<Usser>
    {
        public void Configure(EntityTypeBuilder<Usser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("VARCHAR(100)");
            builder.Property(x => x.Password).HasColumnType("VARCHAR(100)");
        }
    }
}
