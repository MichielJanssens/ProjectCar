using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectCar.Data;
using ProjectCar.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectCar.Services
{
    public class CarService : ICarService
    {
        private readonly EntityContext _entityContext;

        public CarService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public List<Car> GetAllCars()
        {
            return _entityContext.Cars.Include(x => x.CarType).Include(x => x.Owner).ToList();
        }

        public List<CarType> GetAllBrands()
        {
            return _entityContext.CarTypes.Include(x => x.Cars).ThenInclude(x => x.Owner).ToList();
        }

        public List<Owner> GetAllOwners()
        {
            return _entityContext.Owners.Include(x => x.Cars).ThenInclude(x => x.CarType).ToList();
        }

        public Car GetCarById(int id)
        {
            return _entityContext.Cars.Include(x => x.Owner).Include(x => x.CarType).FirstOrDefault(x => x.Id == id);
        }

        public Owner GetOwnerById(int id)
        {
            return _entityContext.Owners.Find(id);
        }

        public CarType GetCarTypeById(int id)
        {
            return _entityContext.CarTypes.Find(id);
        }

        public List<CarType> GetAllCarsTypes()
        {
            return _entityContext.CarTypes.ToList();
        }

        public void Save(Car car)
        {
            if (car.Id == 0)
                _entityContext.Cars.Add(car);
            else
                _entityContext.Cars.Update(car);

            _entityContext.SaveChanges();
        }

        public Car GetOnlyCarById(int id)
        {
            return _entityContext.Cars.Find(id);
        }

        public void DeleteById(int id)
        {
            var carToDelete = GetOnlyCarById(id);
            if (carToDelete != null)
            {
                _entityContext.Cars.Remove(carToDelete);
                _entityContext.SaveChanges();
            }
        }
    }
}
