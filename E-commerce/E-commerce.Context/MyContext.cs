using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_commerce.Context
{
    public class MyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-KUS6R1I\\SQLEXPRESS; Initial Catalog = MyEcommerce_Project; Integrated Security = True; Encrypt = false");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ضبط IsDeleted كـ default false لكل الكيانات اللي عندها الخاصية دي
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProp = entityType.FindProperty("IsDeleted");
                if (isDeletedProp != null)
                {
                    isDeletedProp.SetDefaultValue(false);
                }
            }


            modelBuilder.Entity<Order>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Cart>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<CartItem>().HasQueryFilter(ci => !ci.IsDeleted);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(oi => !oi.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);

            //=========================================================================================================

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);

            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Admin", Email = "admin@test.com", Password = "123456", Role = "Admin"},
            new User { Id = 2, Name = "Mohamed", Email = "mohamed@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 3, Name = "Sara", Email = "sara@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 4, Name = "Ali", Email = "ali@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 5, Name = "Omar", Email = "omar@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 6, Name = "Nour", Email = "nour@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 7, Name = "Khaled", Email = "khaled@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 8, Name = "Huda", Email = "huda@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 9, Name = "Mona", Email = "mona@test.com", Password = "123456", Role = "Customer"},
            new User { Id = 10, Name = "Tamer", Email = "tamer@test.com", Password = "123456", Role = "Customer"}
            );


            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Electronic devices" , IsDeleted = false },
            new Category { Id = 2, Name = "Clothes", Description = "Men & Women clothes" , IsDeleted = false },
            new Category { Id = 3, Name = "Books", Description = "Educational & Novels", IsDeleted = false },
            new Category { Id = 4, Name = "Furniture", Description = "Home & Office furniture" , IsDeleted = false },
            new Category { Id = 5, Name = "Toys", Description = "Kids toys" , IsDeleted = false },
            new Category { Id = 6, Name = "Shoes", Description = "All kinds of shoes", IsDeleted = false },
            new Category { Id = 7, Name = "Beauty", Description = "Cosmetics & skincare" , IsDeleted = false },
            new Category { Id = 8, Name = "Sports", Description = "Sports equipment" , IsDeleted = false },
            new Category { Id = 9, Name = "Food", Description = "Groceries & snacks" , IsDeleted = false },
            new Category { Id = 10, Name = "Mobile", Description = "Smartphones & accessories" , IsDeleted = false }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 15000, Description = "HP Laptop", Stock = 10, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.08_2bc92a76.jpg", CategoryId = 1, IsDeleted = false },
            new Product { Id = 2, Name = "T-Shirt", Price = 250, Description = "Cotton T-Shirt", Stock = 50, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.08.15_5f93ade3.jpg", CategoryId = 2, IsDeleted = false },
            new Product { Id = 3, Name = "Novel", Price = 120, Description = "Arabic Novel", Stock = 30, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.06_3d0a4f09.jpg", CategoryId = 3, IsDeleted = false },
            new Product { Id = 4, Name = "Office Chair", Price = 2000, Description = "Comfort chair", Stock = 15, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.07_5200513d.jpg", CategoryId = 4, IsDeleted = false },
            new Product { Id = 5, Name = "Football", Price = 300, Description = "Adidas Football", Stock = 20, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.08_4fa09fe3.jpg", CategoryId = 8, IsDeleted = false },
            new Product { Id = 6, Name = "Sneakers", Price = 600, Description = "Nike sneakers", Stock = 40, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.07_9717e371.jpg", CategoryId = 6, IsDeleted = false },
            new Product { Id = 7, Name = "Perfume", Price = 450, Description = "Luxury perfume", Stock = 25, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.07_026a458c.jpg", CategoryId = 7, IsDeleted = false },
            new Product { Id = 8, Name = "Smartphone", Price = 10000, Description = "Samsung Galaxy", Stock = 18, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.06_f70df6dc.jpg", CategoryId = 10, IsDeleted = false },
            new Product { Id = 9, Name = "Toy Car", Price = 150, Description = "Remote car", Stock = 35, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.07.06_933c83ad.jpg", CategoryId = 5, IsDeleted = false },
            new Product { Id = 10, Name = "Pizza", Price = 80, Description = "Italian Pizza", Stock = 100, ImagePath = "Media/WhatsApp Image 2025-09-11 at 17.08.33_c949b35b.jpg", CategoryId = 9, IsDeleted = false }
            );




        }


    }
}
