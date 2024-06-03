using Domain.OrderProducts;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasConversion(
                orderId => orderId.Value,
                value => new OrderId(value));

            builder.Property(o => o.Date);

            builder.Property(o => o.CustomerId).IsRequired();

            builder.HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.Total);

            builder.Property(o => o.Address);
        }
    }
}
