using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Context.configration
{
    public class ConfigrationCartItem : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(ci => ci.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);

            // Relations
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId);

            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p.CartItems)
                   .HasForeignKey(ci => ci.ProductId);
        }
    }

}
