using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string usersXml = File.ReadAllText(@"D:\XMLProcessing-ProductShop\ProductShop\Datasets\categories-products.xml");

            using (var context = new ProductShopContext())  //otherwise use DI container to take care of disposing
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //Console.WriteLine(ImportCategoryProducts(context, usersXml));
                Console.WriteLine(GetUsersWithProducts(context));
            }

        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));


            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<User> allUsers = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                allUsers.Add(user);
            }

            context.Users.AddRange(allUsers);
            int importedUsers = context.SaveChanges();

            return $"Successfully imported {importedUsers}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> allProducts = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.sellerId,
                    BuyerId = productDto.buyerId
                };

                allProducts.Add(product);
            }
            context.Products.AddRange(allProducts);
            int importedProducts = context.SaveChanges();

            return $"Successfully imported {importedProducts}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            // here are all including null values => filter before adding to the DB
            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Category> allCategories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }

                var category = new Category
                {
                    Name = categoryDto.Name
                };

                allCategories.Add(category);
            }
            context.Categories.AddRange(allCategories);
            int importedCategories = context.SaveChanges();

            return $"Successfully imported {importedCategories}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryIds = context.Categories
                .Select(c => c.Id)
                .ToHashSet();
                                                        //optimize it with Find();
            var productIds = context.Products
                .Select(p => p.Id)
                .ToHashSet();

            List<CategoryProduct> allCategoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                if (!categoryIds.Contains(categoryProductDto.CategoryId)
                    || !productIds.Contains(categoryProductDto.ProductId))
                {
                    continue;
                }
                var categoryProduct = new CategoryProduct
                {
                    CategoryId = categoryProductDto.CategoryId,
                    ProductId = categoryProductDto.ProductId
                };

                allCategoriesProducts.Add(categoryProduct);
            }
            context.CategoryProducts.AddRange(allCategoriesProducts);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,    // if one of them is null => Buyer will be null => ? null :....
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName 
                })
                .ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new UserSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ProductDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(UserSoldProductsDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoriesDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,       //try avg & /count???? count not working!!!
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(CategoriesDto[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderByDescending(p => p.ProductsSold.Count)
                .Select(u => new UsersAndProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ProductDto
                        {
                            Name= p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var customExport = new CustomUserDto
            {
                Count = context
                       .Users
                       .Count(u => u.ProductsSold.Any()),
                UsersAndProductsDto = users
            };

            XmlSerializer xmlSerializer =
               new XmlSerializer(typeof(CustomUserDto), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}