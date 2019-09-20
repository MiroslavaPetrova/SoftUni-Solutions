using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string jsonFile = File.ReadAllText(@"D:\JSONProcessing-CarDealer\CarDealer\Datasets\cars.json");

            Console.WriteLine(ImportCars(context, jsonFile));

            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            int importedSuppliers = context.SaveChanges();

            return $"Successfully imported {importedSuppliers}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers
               .Select(s => s.Id)
               .ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            List<Part> validParts = new List<Part>();

            foreach (var part in parts)
            {
                if (!supplierIds.Contains(part.SupplierId))
                {
                    continue;
                }

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            int importedParts = context.SaveChanges();

            return $"Successfully imported {importedParts}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);
            context.Cars.AddRange(cars);

            CarDto[] carDtos = JsonConvert.DeserializeObject<CarDto[]>(inputJson);

            HashSet<PartCar> partCars = new HashSet<PartCar>();

            foreach (var car in carDtos)
            {
                int carId = context.Cars
                    .Where(x => x.Make == car.Make
                        && x.Model == car.Model
                        && x.TravelledDistance == car.TravelledDistance)
                    .Select(y => y.Id)
                    .FirstOrDefault();

                foreach (var partId in car.partsId)
                {
                    if (partCars.Where(x => x.CarId == carId && x.PartId == partId).FirstOrDefault() == null)
                    {
                        partCars.Add(new PartCar
                        {
                            CarId = carId,
                            PartId = partId
                        });
                    }
                }
            }
            
            context.PartCars.AddRange(partCars);
            var importedCars = context.SaveChanges();  // throws exception

            return $"Successfully imported {importedCars}.";

        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var cusmomers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(cusmomers);
            int importedCustomers = context.SaveChanges();

            return $"Successfully imported {importedCustomers}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            var importedSales = context.SaveChanges();

            return $"Successfully imported {importedSales}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd/MM/yyyy",
            });

            return json;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ToyotaCarDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            string json = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
           
            return json;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    }).ToList()
                }).ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1) 
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                    //A price of a car is formed by total price of its parts.
                })
                .OrderByDescending(b => b.spentMoney)
                .OrderByDescending(b => b.boughtCars)
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",   // || ToString("F2")
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount =
                    $"{s.Car.PartCars.Sum(p => p.Part.Price) - (s.Car.PartCars.Sum(p => p.Part.Price) * (s.Discount / 100)):F2}",
                }).ToList();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;

        }
    }
}