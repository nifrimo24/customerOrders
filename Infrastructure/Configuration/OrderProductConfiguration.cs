using Domain.Customers;
using Domain.OrderProducts;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts");

            builder.HasKey(op => new { op.OrderId, op.ProductId });

            builder.Property(op => op.OrderId).IsRequired();

            builder.Property(op => op.ProductId).IsRequired();

            builder.Property(op => op.Quantity).IsRequired();

            builder.HasOne<Product>("Product")
            .WithMany()
            .HasForeignKey(op => op.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
