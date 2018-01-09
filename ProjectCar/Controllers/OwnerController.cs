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
    public class OwnerController : Controller
    {
        private readonly ICarService _carService;

        public OwnerController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("/owners")]
        public IActionResult Index()
        {
            var model = new OwnerListViewModel { Owners = new List<OwnerDetailViewModel>() };
            model.Owners.AddRange(_carService.GetAllOwners().Select(ConvertToOwnerDetailViewModel).ToList());
            return View(model);
        }

        protected OwnerDetailViewModel ConvertToOwnerDetailViewModel(Owner owner)
        {
            var cars = new List<CarDetailViewModel>();
            cars.AddRange(owner.Cars.Select(ConvertToCarDetailViewModel).ToList());

            return new OwnerDetailViewModel()
            {
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
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
