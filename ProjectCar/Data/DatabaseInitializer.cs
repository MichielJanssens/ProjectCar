using ProjectCar.Data;
using ProjectCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autos.Data
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase(EntityContext entityContext)
        {
            entityContext.Database.EnsureCreated();

            var owners = new List<Owner>
            {
                new Owner() {FirstName = "Heidi", LastName = "Decat"},
                new Owner() {FirstName = "Michiel", LastName = "Janssens"},
                new Owner() {FirstName = "Bram", LastName = "Janssens"},
                new Owner() {FirstName = "Bart", LastName = "Janssens"}
            };

            var carTypes = new List<CarType>
            {
                new CarType() {Model = "Jaris", Brand = "Toyota"},
                new CarType() {Model = "Transporter", Brand = "Volkswagen"},
                new CarType() {Model = "Civico", Brand = "Renault"},
                new CarType() {Model = "Century", Brand = "Toyota"}
            };

            List<string> colours = new List<string>
            {
                "Red",
                "Yellow",
                "Blue",
                "Green",
                "Pink",
                "Orange",
                "Black",
                "White"
            };

            List<string> licenseplates = new List<string>
            {
                "DAE-485",
                "AGE-453",
                "YEF-453",
                "YEH-115",
                "YHA-069",
                "KLM-112",
                "ARE-129",
                "TIT-069"
            };


            var cars = new List<Car>();
            for(var i = 0; i < 20; i++)
            {
                Random rnd = new Random();

                CarType carType = carTypes[rnd.Next(0, 4)];
                Owner owner = owners[rnd.Next(0, 4)];
                string colour = colours[rnd.Next(0, 8)];
                string licenseplate = licenseplates[rnd.Next(0, 8)];

                cars.Add(new Car { Colour = colour, Purchase = new DateTime(2018, 01,01), LicensePlate = licenseplate, CarType = carType, Owner = owner });
            }

            entityContext.Owners.AddRange(owners);
            entityContext.CarTypes.AddRange(carTypes);
            entityContext.Cars.AddRange(cars);
            entityContext.SaveChanges();
        }
    }
}
