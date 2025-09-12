using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Context.configration
{
    public class ConfigrationCatogery : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(c => c.Description)
                    .HasMaxLength(250);

            // Relations (One Category -> Many Products)
            builder.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId);
        }
    }

}
