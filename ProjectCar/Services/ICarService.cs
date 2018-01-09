using ProjectCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Services
{
        public interface ICarService
        {
            List<Car> GetAllCars();
            List<CarType> GetAllBrands();
            Car GetCarById(int id);
            Owner GetOwnerById(int id);
            CarType GetCarTypeById(int id);
            List<Owner> GetAllOwners();
            List<CarType> GetAllCarsTypes();

            void Save(Car car);
            void DeleteById(int id);
        }
}
