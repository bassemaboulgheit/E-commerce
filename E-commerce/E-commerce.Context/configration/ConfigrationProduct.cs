using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Context.configration
{
    public class ConfigrationProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Primary Key
            builder.HasKey(c => c.Id);


            // Properties
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Stock)
                   .IsRequired();


            // Relations
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasMany(p => p.CartItems)
                   .WithOne(ci => ci.Product)
                   .HasForeignKey(ci => ci.ProductId);

            builder.HasMany(p => p.OrderItems)
                   .WithOne(oi => oi.Product)
                   .HasForeignKey(oi => oi.ProductId);
        }
    }

}
