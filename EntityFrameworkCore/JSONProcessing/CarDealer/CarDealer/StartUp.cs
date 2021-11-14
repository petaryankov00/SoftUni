using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var inputJson = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        //Problem01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitizalizeMapper();
            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //Problem02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitizalizeMapper();
            var partsDto = JsonConvert.DeserializeObject<ICollection<PartInputModel>>(inputJson)
                .Where(x => x.SupplierId <= 31 && x.SupplierId >= 1)
                .ToList();

            var parts = mapper.Map<ICollection<Part>>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";


        }

        //Problem 03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ICollection<CarInputModel>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };
                foreach (var carPartId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        Car = currentCar,
                        PartId = carPartId
                    });
                }
                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}."; ;
        }

        //Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitizalizeMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";


        }

        //Problem 05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitizalizeMapper();

            var carIds = context.Cars.Select(x => x.Id).ToList();
            var customerIds = context.Customers.Select(x => x.Id).ToList();

            var salesDto = JsonConvert.DeserializeObject<ICollection<SaleInputModel>>(inputJson);
            //.Where(x=>carIds.Any(c=> c == x.CarId) && customerIds.Any(c=> c == x.CustomerId));

            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //Problem 06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = $"{x.BirthDate.ToString("dd/MM/yyyy")}",
                    x.IsYoungDriver
                })
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var customersJson = JsonConvert.SerializeObject(customers, options);

            return customersJson;
        }

        //Problem 07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var carsJson = JsonConvert.SerializeObject(cars, options);

            return carsJson;
        }

        //Problme 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var suppliersJson = JsonConvert.SerializeObject(suppliers, options);

            return suppliersJson;

        }

        //Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new { Make = x.Make, Model = x.Model, TravelledDistance = x.TravelledDistance },
                    parts = x.PartCars.Select(y => new
                    {
                        Name = y.Part.Name,
                        Price = $"{y.Part.Price:F2}"
                    })
                })
                .ToList();

            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
            };

            var carsJson = JsonConvert.SerializeObject(cars, options);

            return carsJson;
        }

        //Problem 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
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

            var customersJson = JsonConvert.SerializeObject(customers, options);

            return customersJson;
        }

        //Problem 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Take(10)
                .Select(x => new
                {
                    car = new { Make = x.Car.Make, Model = x.Car.Model, TravelledDistance = x.Car.TravelledDistance },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("f2"),
                    price = (x.Car.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))).ToString("f2"),
                    priceWithDiscount =
                    (x.Car.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price)) - x.Car.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price)) * (x.Discount / 100)).ToString("f2")
                })
                .ToList();

            string output = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return output;
        }

        public static void InitizalizeMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}