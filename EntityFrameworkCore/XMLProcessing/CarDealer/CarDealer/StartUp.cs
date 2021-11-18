using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //var inputXml = File.ReadAllText("Datasets/sales.xml");
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            Console.WriteLine(GetSalesWithAppliedDiscount(db));

        }


        //Problem 01
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Suppliers";
            var serializer = new XmlSerializer(typeof(List<SupplierInputModel>), xRoot);
            var suppliersDto = (List<SupplierInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var suppliers = mapper.Map<List<Supplier>>(suppliersDto);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";

        }

        //Problem 02
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Parts";
            var serializer = new XmlSerializer(typeof(List<PartInputModel>), xRoot);
            var partsDto = (List<PartInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var supplierIds = context.Suppliers.Select(x => x.Id).ToArray();

            var parts = mapper.Map<List<Part>>(partsDto)
                .Where(x => supplierIds.Any(s => s == x.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Problem 03
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Cars";
            var serializer = new XmlSerializer(typeof(List<CarInputModel>), xRoot);
            var partIds = context.Parts.Select(x => x.Id).ToArray();
            var carsDto = (List<CarInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var cars = carsDto.Select(x => new Car
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TraveledDistance,
                PartCars = x.Parts
                .Select(x => x.Id)
                .Distinct()
                .Intersect(partIds)
                .Select(pc => new PartCar
                {
                    PartId = pc
                })
                .ToList()

            }).ToList();

            //var cars = new List<Car>();

            //foreach (var c in carsDto)
            //{
            //    var currentCar = new Car
            //    {
            //        Make = c.Make,
            //        Model = c.Model,
            //        TravelledDistance = c.TraveledDistance
            //    };

            //    foreach (var part in c.Parts.Distinct())
            //    {
            //        if (partIds.Contains(part.Id))
            //        {
            //            continue;
            //        }
            //        currentCar.PartCars.Add(new PartCar
            //        {
            //            PartId = part.Id
            //        });
            //    }
            //    cars.Add(currentCar);
            //}

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }

        //Problem 04
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Customers";
            var serializer = new XmlSerializer(typeof(List<CustomerInputModel>), xRoot);
            var customersDto = (List<CustomerInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var customers = mapper.Map<List<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 05
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Sales";
            var serializer = new XmlSerializer(typeof(List<SaleInputModel>), xRoot);
            var salesDto = (List<SaleInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var carIds = context.Cars.Select(x => x.Id).ToList();

            var sales = mapper.Map<List<Sale>>(salesDto)
                .Where(x => carIds.Any(c => c == x.CarId))
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 06
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "cars";
            var serializer = new XmlSerializer(typeof(List<CarOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 07
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarFromBMWModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance

                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "cars";
            var serializer = new XmlSerializer(typeof(List<CarFromBMWModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();

        }

        //Problem 08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Parts.Count,
                })
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "suppliers";
            var serializer = new XmlSerializer(typeof(List<SupplierOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Cars
                .Select(x => new CarWithProductsModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "cars";
            var serializer = new XmlSerializer(typeof(List<CarWithProductsModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var customers = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "customers";
            var serializer = new XmlSerializer(typeof(List<CustomerOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();

        }

        //Problem 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sales = context.Sales
                .Select(x => new SaleOutputModel
                {
                    Car = new CarOutputModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    CustomerName = x.Customer.Name,
                    Discount = x.Discount,
                    Price = x.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(x => x.Part.Price) - (x.Car.PartCars.Sum(x => x.Part.Price)) * x.Discount * 1.0m / 100.0m
                })
                .ToList();

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "sales";
            var serializer = new XmlSerializer(typeof(List<SaleOutputModel>), xRoot);


            serializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().Trim();
        }


        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}