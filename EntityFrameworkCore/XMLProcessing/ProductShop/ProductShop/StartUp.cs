using ProductShop.Data;
using ProductShop.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using AutoMapper;
using ProductShop.Models;
using System.Linq;
using System.Text;
using ProductShop.Dtos.Output;
using ProductShop.Dtos.Input;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            var inputXml = File.ReadAllText("Datasets/categories-products.xml");
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            var serializer = new XmlSerializer(typeof(List<UserDtoModel>), xRoot);
            var usersDto = (List<UserDtoModel>)serializer.Deserialize(new StringReader(inputXml));

            var users = mapper.Map<List<User>>(usersDto);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";

        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Products";
            var serializer = new XmlSerializer(typeof(List<ProductDtoModel>), xRoot);
            var productsDto = (List<ProductDtoModel>)serializer.Deserialize(new StringReader(inputXml));

            var products = mapper.Map<List<Product>>(productsDto);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Categories";
            var serializer = new XmlSerializer(typeof(List<CategoryDtoModel>), xRoot);
            var categoriesDto = (List<CategoryDtoModel>)serializer.Deserialize(new StringReader(inputXml));

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto)
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "CategoryProducts";
            var serializer = new XmlSerializer(typeof(List<CategoryProductDtoModel>), xRoot);
            var categoriesProductsDto = (List<CategoryProductDtoModel>)serializer.Deserialize(new StringReader(inputXml));

            var productIds = context.Products.Select(x => x.Id).ToList();
            var categoryIds = context.Categories.Select(x => x.Id).ToList();

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProductsDto)
                .Where(x => productIds.Any(p => p == x.ProductId) && categoryIds.Any(c => c == x.CategoryId))
                .ToList();


            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductInRangeOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .Take(10)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Products";
            var serializer = new XmlSerializer(typeof(List<ProductInRangeOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new UserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Where(p => p.BuyerId != null)
                    .Select(p => new ProductOutputDtoModel
                    {
                        Name = p.Name,
                        Price = p.Price

                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            var serializer = new XmlSerializer(typeof(List<UserOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problme 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var categories = context.Categories
                .Select(x => new CategoryOutputModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Categories";
            var serializer = new XmlSerializer(typeof(List<CategoryOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();

        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var users = context.Users
                .ToArray()
                   .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                   .OrderByDescending(x => x.ProductsSold.Count)
                   .Select(x => new ExportUserOutputModel
                   {
                       FirstName = x.FirstName,
                       LastName = x.LastName,
                       Age = x.Age,
                       SoldProducts = new ProductsCountModel
                       {
                           Count = x.ProductsSold.Count(),
                           Products = x.ProductsSold.Select(s => new ProductOutputDtoModel
                           {
                               Name = s.Name,
                               Price = s.Price

                           })
                           .OrderByDescending(s => s.Price)
                           .ToArray()
                       }
                   })
                   .ToArray();

            var result = new UserWithProductsModel
            {
                Count = users.Count(),
                Users = users.Take(10).ToArray()
            };


            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            var serializer = new XmlSerializer(typeof(UserWithProductsModel), xRoot);


            serializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}