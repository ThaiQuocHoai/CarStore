using Mercedes.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(x => new { x.CarID, x.OrderID });
            builder.HasOne(t => t.Car).WithMany(x => x.OrderDetails).HasForeignKey(x => x.CarID);
            builder.HasOne(o => o.Order).WithMany(od => od.OrderDetails).HasForeignKey(o => o.OrderID);
        }
    }
}
