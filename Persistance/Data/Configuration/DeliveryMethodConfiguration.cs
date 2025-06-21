using Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data.Configuration
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");

            builder.Property(d => d.Price)
                .HasColumnType("decimal(8,2)");

            builder.Property(d => d.ShortName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(D=>D.Description)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(D => D.DeliveryTime)
                .HasColumnType("varchar")
                .HasMaxLength(50);

           

        }
    }
}
