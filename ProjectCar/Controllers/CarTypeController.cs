using Microsoft.AspNetCore.Mvc;
using ProjectCar.Entities;
using ProjectCar.Models;
using ProjectCar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Controllers
{
    public class CarTypeController : Controller
    {
        private readonly ICarService _carService;

        public CarTypeController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("/brands")]
        public IActionResult Index()
        {
            var model = new CarTypeListViewModel { Brands = new List<CarTypeDetailViewModel>() };
            model.Brands.AddRange(_carService.GetAllBrands().Select(ConvertToBrandDetailViewModel).ToList());
            return View(model);
        }

        protected CarTypeDetailViewModel ConvertToBrandDetailViewModel(CarType carType)
        {
            var cars = new List<CarDetailViewModel>();
            cars.AddRange(carType.Cars.Select(ConvertToCarDetailViewModel).ToList());

            return new CarTypeDetailViewModel()
            {
                Id = carType.Id,
                Name = carType.Brand,
                Model = carType.Model,
                Cars = cars
            };
        }

        protected CarDetailViewModel ConvertToCarDetailViewModel(Car car)
        {
            return new CarDetailViewModel()
            {
                Id = car.Id,
                Colour = car.Colour,
                Purchase = car.Purchase,
                LicensePlate = car.LicensePlate,
                Owner = car.Owner,
                CarType = car.CarType
            };
        }
    }
}