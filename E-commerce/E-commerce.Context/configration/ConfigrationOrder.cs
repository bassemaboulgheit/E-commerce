using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Context.configration
{
    public class ConfigrationOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(o => o.OrderDate)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            //builder.Property(o => o.TotalAmount)
            //       .IsRequired()
            //       .HasColumnType("decimal(18,2)");
            builder.Ignore(o => o.TotalAmount);


            builder.Property(o => o.orderStatus)
               .HasConversion<int>()
               .IsRequired()
               .HasDefaultValue(OrderStatus.Pending);



            // Relations
            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);
        }
    }

}
