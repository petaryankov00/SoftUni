using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(GetUsersWithProducts(db));

        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";


        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var productsDto = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";

        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var categoriesDto = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson);

            var categoires = mapper.Map<IEnumerable<Category>>(categoriesDto)
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(categoires);
            context.SaveChanges();

            return $"Successfully imported {categoires.Count()}";


        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var categoryProductsDto = JsonConvert.DeserializeObject<IEnumerable<CategoryProductsInputDto>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = $"{x.Price:f2}",
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}",
                })
                .OrderBy(x => x.Price)
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string outputJson = JsonConvert.SerializeObject(products, options);

            return outputJson;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    soldProducts = x.ProductsSold.Where(s=>s.BuyerId!=null).Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var jsonOutput = JsonConvert.SerializeObject(users, options);

            return jsonOutput;

        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = $"{x.CategoryProducts.Average(c => c.Product.Price):f2}",
                    totalRevenue = $"{x.CategoryProducts.Sum(c => c.Product.Price):f2}"
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
            };

            var jsonOutput = JsonConvert.SerializeObject(categories, options);

            return jsonOutput;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            InitializeAutoMapper();

            var usersDb = context.Users
                .Include(x=>x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Where(p=>p.BuyerId!=null).Count(),
                        products = x.ProductsSold.Where(p=>p.BuyerId!=null)
                        .Select(y => new
                        {
                            name = y.Name,
                            price = y.Price
                        })
                    }
                }).ToArray()
                .OrderByDescending(x=>x.soldProducts.count)
                .ToList();

            var usersOutput = new
            {
                usersCount = usersDb.Count,
                users = usersDb
            };

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
            };

            var jsonOutput = JsonConvert.SerializeObject(usersOutput, options);

            return jsonOutput;
        }


        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}

