using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguraions
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            
            
            Property(x => x.ManufactureEmail)
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAttribute()
                {
                    IsUnique = true
                });

            Property(x => x.ProduceDate)
               .IsRequired()
               .HasColumnAnnotation("Index", new IndexAttribute()
               {
                    IsUnique = true
               });

            Property(x => x.ManufacturePhone)
                .HasMaxLength(50);

            Property(x=> x.Name)
                .HasMaxLength (250);

        }
    }
}
