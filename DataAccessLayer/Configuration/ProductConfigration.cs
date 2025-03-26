using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configuration
{
    class ProductConfigration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(P => P.ProductId);

            builder.Property(P => P.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(P => P.Name).HasMaxLength(100).IsRequired();

            builder.Property(P => P.PhotoLocation).HasDefaultValue("NoPhoto.jpg");

            builder
                .HasMany(po => po.ListOfProduct)
                .WithOne(o => o.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.NoAction); 

        }
    }
}
