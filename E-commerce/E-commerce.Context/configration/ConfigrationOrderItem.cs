using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Context.configration
{
    public class ConfigrationOrderItem : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(oi => oi.Quantity)
               .IsRequired()
               .HasDefaultValue(1);

            builder.Property(oi => oi.UnitPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Relations
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasOne(oi => oi.Product)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(oi => oi.ProductId);
        }
    }

}
