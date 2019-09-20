using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string jsonString = File.ReadAllText(@"D:\JSONProcessing-ProductShop\ProductShop\Datasets\categories-products.json");

            //Console.WriteLine(ImportCategoryProducts(context, jsonString));

            Console.WriteLine(GetUsersWithProducts(context));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            //last name (at least 3 characters) 

            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson)
                .Where(u => u.LastName != null &&  u.LastName.Length >= 3)
                .ToList();

            context.Users.AddRange(users);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson)
                .Where(p => p.Name.Length >= 3)
                .ToList();

            context.Products.AddRange(products);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null && c.Name.Length >=3 && c.Name.Length <= 15)
                .ToList();

            context.Categories.AddRange(categories);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var allCategoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(allCategoriesProducts);

            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller =  p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            string json =  JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,                                  //try without this one => OK E
                    soldProducts = u.ProductsSold.Where(ps => ps.Buyer != null && u.ProductsSold.Count >= 1)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price,
                                        buyerFirstName = p.Buyer.FirstName,
                                        buyerLastName = p.Buyer.LastName
                                    }).ToList()
                }).ToList();
            //for judge
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            // better skip the null values

            //string json = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore,
            //}
            //);

            return json;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):F2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
                }).ToList();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new
            {
                usersCount = context.Users.Count(),
                users = context.Users
                        .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(p => p.Buyer != null))
                        .OrderByDescending(p => p.ProductsSold.Count)
                        .Select(u => new
                        {
                            firstName = u.FirstName,
                            lastName = u.LastName,
                            age = u.Age,
                            soldProducts = new
                            {
                                count = u.ProductsSold.Count,
                                products = u.ProductsSold
                               .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    })
                            }
                        })
            };

            string json = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }
    }
}