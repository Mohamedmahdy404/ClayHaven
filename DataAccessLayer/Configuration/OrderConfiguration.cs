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
    class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.CustomerName).HasMaxLength(70);
            builder.Property(P => P.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();


            builder
                .HasMany(OP => OP.ListOfProduct) //the collection (old table)
                .WithOne(o => o.Order) //the obj (new table)
                .HasForeignKey(p => p.OrderId) //the forgienkey (new table)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
