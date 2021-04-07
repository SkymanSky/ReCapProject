using Business.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Indexing();

            Console.WriteLine("----------Added Car------------");

            EfCarDal addNewCarDal = new EfCarDal();
            addNewCarDal.Add(new Car
            {
                Description ="Honda-Civic",
                DailyPrice = 18,
                ModelYear = "2018",
                BrandId = 2,
                ColorId = 1
            });

            Indexing();

            Console.WriteLine("----------Tested Add Car Rule------------");

            addNewCarDal.Add(new Car
            {
                Description = "H",
                DailyPrice = -1,
                ModelYear = "2018",
                BrandId = 2,
                ColorId = 1
            });
        }

        private static CarManager Indexing()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(
                    "Araba Tanımı:{0} - Araba Fiyatı:{1}, Araba Modeli:{2}, Araba Markası:{3}, Araba Rengi:{4}",
                    car.Description, car.DailyPrice, car.ModelYear, car.BrandId, car.ColorId);
            }

            return carManager;
        }
    }
}
