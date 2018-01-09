using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCar.Entities;
using ProjectCar.Models;
using ProjectCar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("/cars")]
        public IActionResult Index()
        {
            var model = new CarListViewModel { Cars = new List<CarDetailViewModel>() };
            model.Cars.AddRange(_carService.GetAllCars().Select(ConvertToCarDetailViewModel).ToList());
            return View(model);
        }

        [HttpGet("/cars/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            CarEditViewModel model;

            var selectedCar = _carService.GetCarById(id);

            if (selectedCar == null)
            {
                model = new CarEditViewModel
                {
                    Id = 0,
                    LicensePlate = "",
                    Purchase = DateTime.Now,
                    Owner = "",
                    OwnerId = 0,
                    CarType = "",
                    CarTypeId = 0
                };
            }
            else
            {
                model = ConvertToCarEditViewModel(selectedCar);
            }

            model.Owners = _carService.GetAllOwners().Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString()
            }).ToList();

            model.CarTypes = _carService.GetAllCarsTypes().Select(x => new SelectListItem
            {
                Text = x.Brand + " " + x.Model,
                Value = x.Id.ToString()
            }).ToList();

            return View(model);
        }

        [HttpPost("/cars")]
        public IActionResult Save([FromForm] CarEditViewModel form)
        {
            Car car;
            if (form.Id == 0)
            {
                car = new Car();
            }
            else
            {
                car = _carService.GetCarById(form.Id);
            }

            car.LicensePlate = form.LicensePlate;
            car.Owner = _carService.GetOwnerById((int)form.OwnerId.Value);
            car.CarType = _carService.GetCarTypeById((int)form.CarTypeId.Value);
            _carService.Save(car);

            return Redirect("/cars");
        }

        [HttpPost("/cars/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _carService.DeleteById(id);
            return Redirect("/cars");
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

        protected CarEditViewModel ConvertToCarEditViewModel(Car car)
        {
            return new CarEditViewModel()
            {
                Id = car.Id,
                LicensePlate = car.LicensePlate,
                Purchase = car.Purchase,
                Owner = car.Owner.FirstName + " " + car.Owner.LastName,
                OwnerId = car.Owner.Id,
                CarType = car.CarType.Brand + " " + car.CarType.Model,
                CarTypeId = car.CarType.Id
            };
        }
    }
}