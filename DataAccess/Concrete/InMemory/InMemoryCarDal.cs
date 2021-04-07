using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal  : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car
                {
                    Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 2, Description = "Nissan-Qashqai",
                    ModelYear = "2020"
                },
                new Car
                {
                    Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 3, Description = "Hyundai-Accent",
                    ModelYear = "2019"
                },
                new Car
                {
                    Id = 3, BrandId = 1, ColorId = 1, DailyPrice = 5, Description = "Renault-Captur",
                    ModelYear = "2017"
                },
                new Car
                {
                    Id = 4, BrandId = 1, ColorId = 1, DailyPrice = 7, Description = "Fiat-Doblo",
                    ModelYear = "2015"
                },
                new Car
                {
                    Id = 5, BrandId = 1, ColorId = 1, DailyPrice = 8, Description = "Skoda-Superb",
                    ModelYear = "2010"
                },

            };
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carsToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
