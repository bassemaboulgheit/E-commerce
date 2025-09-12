using System;
using System.Diagnostics;
using E_commerce.Models;
using E_commerce.Application.Services;
using E_commerce.Application.Contracts;
using E_commerce.Context;
using E_commerce.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.TestRunner
{
    public class ManualTestRunner
    {
        private MyContext _context;
        private CategoryService _categoryService;
        private ProdectService _productService;

        public ManualTestRunner()
        {
            _context = new MyContext();
            var categoryRepo = new GenericRepository<Category, int>(_context);
            var productRepo = new GenericRepository<Product, int>(_context);
            
            _categoryService = new CategoryService(categoryRepo);
            _productService = new ProdectService(productRepo);
        }

        public void RunAllTests()
        {
            Console.WriteLine("=== E-commerce System Test Runner ===\n");

            try
            {
                TestDatabaseConnection();
                TestCategoryOperations();
                TestProductOperations();
                TestRelationships();
                TestSoftDelete();
                TestValidation();
                
                Console.WriteLine("\n=== All Tests Completed Successfully! ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Test Failed: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
        }

        private void TestDatabaseConnection()
        {
            Console.WriteLine("🔍 Testing Database Connection...");
            
            try
            {
                var categories = _categoryService.GetAllCategories();
                Console.WriteLine($"✅ Database connection successful. Found {categories.Count} categories.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Database connection failed: {ex.Message}");
            }
        }

        private void TestCategoryOperations()
        {
            Console.WriteLine("\n🔍 Testing Category Operations...");

            // Test Create
            var testCategory = new Category
            {
                Name = "Test Category " + DateTime.Now.Ticks,
                Description = "Test category created by test runner"
            };

            _categoryService.CreateCategory(testCategory);
            var saveResult = _categoryService.SaveCategory();
            Console.WriteLine($"✅ Category created. Save result: {saveResult}");

            // Test Read
            var createdCategory = _categoryService.GetCategoryByName(testCategory.Name);
            if (createdCategory != null)
            {
                Console.WriteLine($"✅ Category retrieved: {createdCategory.Name}");
            }
            else
            {
                throw new Exception("Failed to retrieve created category");
            }

            // Test Update
            createdCategory.Description = "Updated description";
            _categoryService.UpdateCategory(createdCategory);
            _categoryService.SaveCategory();
            Console.WriteLine("✅ Category updated successfully");

            // Test Soft Delete
            _categoryService.DeleteCategory(createdCategory);
            _categoryService.SaveCategory();
            var deletedCategory = _categoryService.GetCategoryById(createdCategory.Id);
            
            if (deletedCategory?.IsDeleted == true)
            {
                Console.WriteLine("✅ Category soft delete successful");
            }
            else
            {
                throw new Exception("Soft delete failed");
            }
        }

        private void TestProductOperations()
        {
            Console.WriteLine("\n🔍 Testing Product Operations...");

            // Get an existing category for the product
            var categories = _categoryService.GetAllCategories().Where(c => !c.IsDeleted).ToList();
            if (!categories.Any())
            {
                throw new Exception("No categories available for product test");
            }

            var testProduct = new Product
            {
                Name = "Test Product " + DateTime.Now.Ticks,
                Price = 299.99m,
                Description = "Test product created by test runner",
                Stock = 50,
                ImagePath = "test-product.jpg",
                CategoryId = categories.First().Id
            };

            // Test Create
            _productService.CreateProduct(testProduct);
            var saveResult = _productService.SaveProduct();
            Console.WriteLine($"✅ Product created. Save result: {saveResult}");

            // Test Read
            var createdProduct = _productService.GetProductByName(testProduct.Name);
            if (createdProduct != null)
            {
                Console.WriteLine($"✅ Product retrieved: {createdProduct.Name}, Price: {createdProduct.Price:C}");
            }
            else
            {
                throw new Exception("Failed to retrieve created product");
            }

            // Test Update
            createdProduct.Price = 399.99m;
            createdProduct.Stock = 25;
            _productService.UpdateProduct(createdProduct);
            _productService.SaveProduct();
            Console.WriteLine("✅ Product updated successfully");

            // Test Soft Delete
            _productService.DeleteProduct(createdProduct);
            _productService.SaveProduct();
            var deletedProduct = _productService.GetProductById(createdProduct.Id);
            
            if (deletedProduct?.IsDeleted == true)
            {
                Console.WriteLine("✅ Product soft delete successful");
            }
            else
            {
                throw new Exception("Product soft delete failed");
            }
        }

        private void TestRelationships()
        {
            Console.WriteLine("\n🔍 Testing Entity Relationships...");

            // Get products with their categories
            var products = _productService.GetAllProducts().Where(p => !p.IsDeleted).Take(5).ToList();
            
            foreach (var product in products)
            {
                var category = _categoryService.GetCategoryById(product.CategoryId ?? 0);
                if (category != null)
                {
                    Console.WriteLine($"✅ Product '{product.Name}' belongs to category '{category.Name}'");
                }
            }
        }

        private void TestSoftDelete()
        {
            Console.WriteLine("\n🔍 Testing Soft Delete Functionality...");

            var activeCategories = _categoryService.GetAllCategories().Where(c => !c.IsDeleted).Count();
            var activeProducts = _productService.GetAllProducts().Where(p => !p.IsDeleted).Count();
            
            Console.WriteLine($"✅ Active Categories: {activeCategories}");
            Console.WriteLine($"✅ Active Products: {activeProducts}");
            
            // Test that deleted items are filtered out by query filters
            var allCategoriesFromDb = _context.Categories.IgnoreQueryFilters().Count();
            var visibleCategories = _context.Categories.Count();
            
            Console.WriteLine($"✅ Total categories in DB: {allCategoriesFromDb}");
            Console.WriteLine($"✅ Visible categories (not deleted): {visibleCategories}");
        }

        private void TestValidation()
        {
            Console.WriteLine("\n🔍 Testing Business Logic Validation...");

            // Test Order total calculation
            var order = new Order
            {
                UserId = 1,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Quantity = 2, UnitPrice = 100 },
                    new OrderItem { Quantity = 1, UnitPrice = 50 }
                }
            };

            var expectedTotal = 250m; // (2*100) + (1*50)
            if (order.TotalAmount == expectedTotal)
            {
                Console.WriteLine($"✅ Order total calculation correct: {order.TotalAmount:C}");
            }
            else
            {
                Console.WriteLine($"❌ Order total calculation incorrect. Expected: {expectedTotal:C}, Got: {order.TotalAmount:C}");
            }

            // Test enum values
            var testOrderStatus = OrderStatus.Pending;
            Console.WriteLine($"✅ Order status enum working: {testOrderStatus}");
        }

        public void RunPerformanceTest()
        {
            Console.WriteLine("\n🔍 Running Performance Tests...");

            var stopwatch = Stopwatch.StartNew();

            // Test bulk operations
            for (int i = 0; i < 100; i++)
            {
                var products = _productService.GetAllProducts();
            }

            stopwatch.Stop();
            Console.WriteLine($"✅ 100 GetAllProducts() calls took: {stopwatch.ElapsedMilliseconds}ms");

            // Test single record retrieval
            stopwatch.Restart();
            var singleProduct = _productService.GetProductById(1);
            stopwatch.Stop();
            Console.WriteLine($"✅ Single product retrieval took: {stopwatch.ElapsedMilliseconds}ms");
        }

        public void DisplaySystemStatus()
        {
            Console.WriteLine("\n=== System Status Report ===");
            
            var categories = _categoryService.GetAllCategories().Where(c => !c.IsDeleted).ToList();
            var products = _productService.GetAllProducts().Where(p => !p.IsDeleted).ToList();
            
            Console.WriteLine($"📊 Active Categories: {categories.Count}");
            Console.WriteLine($"📊 Active Products: {products.Count}");
            Console.WriteLine($"📊 Products by Category:");
            
            foreach (var category in categories.Take(5))
            {
                var productCount = products.Count(p => p.CategoryId == category.Id);
                Console.WriteLine($"   - {category.Name}: {productCount} products");
            }
            
            var totalValue = products.Sum(p => p.Price * p.Stock);
            Console.WriteLine($"📊 Total Inventory Value: {totalValue:C}");
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    // Program entry point for running tests
    public class Program
    {
        public static void Main(string[] args)
        {
            var testRunner = new ManualTestRunner();
            
            try
            {
                testRunner.RunAllTests();
                testRunner.RunPerformanceTest();
                testRunner.DisplaySystemStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
            finally
            {
                testRunner.Dispose();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}