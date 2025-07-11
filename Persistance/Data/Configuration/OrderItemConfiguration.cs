﻿using Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem > builder)
        {
            builder.ToTable("OrderItems");

            builder.Property(o => o.Price)
                .HasColumnType("decimal(8,2)");

            builder.OwnsOne(o => o.product);

        }
    }
}
