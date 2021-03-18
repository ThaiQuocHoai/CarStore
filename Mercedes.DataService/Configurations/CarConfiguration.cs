using Mercedes.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.DataService.Configurations
{
    class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car");
            builder.HasKey(x => x.CarId);
            builder.HasOne(x => x.Category).WithMany(x => x.Cars).HasForeignKey(x => x.CategoryID);
        }
    }
}
