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
    class ProductOrderConfiguration: IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {

            builder.HasKey(p => new { p.OrderId, p.ProductId });

            builder
                .HasOne(p => p.Product)
                .WithMany(po => po.ListOfProduct)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder
                .HasOne(O => O.Order) //the obj from the main two tables (on new table)
                .WithMany(PO => PO.ListOfProduct)//the list from the main tables (on old tables)
                .HasForeignKey(p => p.OrderId)// the ForeignKey on the new table (on new table)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
