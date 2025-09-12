using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Context.configration
{
    public class ConfigrationCart : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relations
            //builder.HasOne(c => c.User)
            //       .WithOne(u => u.Carts)
            //       .HasForeignKey<User>(c => c.CartId);

            builder.HasMany(c => c.CartItems)
                   .WithOne(ci => ci.Cart)
                   .HasForeignKey(ci => ci.CartId);
        }
    }

}
