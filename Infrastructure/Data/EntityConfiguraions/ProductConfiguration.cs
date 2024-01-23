using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguraions
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ManufactureEmail)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.ProduceDate)
               .IsRequired();

            builder.Property(x => x.ManufacturePhone)
                .HasMaxLength(50);

            builder.Property(x => x.Name)
                .HasMaxLength(250);

            builder
                .HasIndex(x => new { x.ManufactureEmail, x.ProduceDate })
                .IsUnique();
        }
    }
}
