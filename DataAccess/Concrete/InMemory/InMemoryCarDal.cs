using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car
                {
                    CarId = 1, BrandId = "1", ColorId = "1", DailyPrice = 2.35, Description = "Nissan-Qashqai",
                    ModelYear = "2020"
                },
                new Car
                {
                    CarId = 2, BrandId = "2", ColorId = "1", DailyPrice = 3.35, Description = "Hyundai-Accent",
                    ModelYear = "2019"
                },
                new Car
                {
                    CarId = 3, BrandId = "3", ColorId = "1", DailyPrice = 5.35, Description = "Renault-Captur",
                    ModelYear = "2017"
                },
                new Car
                {
                    CarId = 4, BrandId = "4", ColorId = "1", DailyPrice = 7.35, Description = "Fiat-Doblo",
                    ModelYear = "2015"
                },
                new Car
                {
                    CarId = 5, BrandId = "5", ColorId = "1", DailyPrice = 8.35, Description = "Skoda-Superb",
                    ModelYear = "2010"
                },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carsToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
