using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Ef.Mapping
{
    internal class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.OwnsOne(x => x.Total, b => {
                b.Property(x => x.Value);
              
            });

            //builder.OwnsMany(x => x.OrderItems);


            builder.OwnsMany(x => x.OrderItems, oi =>
            {
               // oi.ToTable("OrderItems").HasKey(x => x.Id);
                oi.Property(p => p.Id).IsRequired().ValueGeneratedNever();
                oi.WithOwner().HasForeignKey("OrderId");
                oi.Property(x => x.ProductId);
                oi.Property(x => x.Quantity);
                oi.Property(x => x.Quantity);
            });
        }
    }
}
