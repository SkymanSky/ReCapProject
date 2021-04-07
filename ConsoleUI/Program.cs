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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(
                    "Araba Tanımı:{0} - Araba Fiyatı:{1}, Araba Modeli:{2}, Araba Markası:{3}, Araba Rengi:{4}", 
                    car.Description,car.DailyPrice,car.ModelYear,car.BrandId,car.ColorId);
            }

        }
    }
}
