using Business.Concrete;
using System;
using System.Threading.Channels;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName+"-"+car.ModelName+"-"+car.ColorName+"-"+car.DailyPrice);
            }

            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "-" + brand.BrandName);
            }

            Console.WriteLine("------Added New Brand-------");

            EfBrandDal addNewBrand = new EfBrandDal();
            addNewBrand.Add(new Brand {BrandName = "BMW"});

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "-" + brand.BrandName);
            }

            Console.WriteLine("------Deleted Existing Brand-------");

            EfBrandDal deletedBrand = new EfBrandDal();
            deletedBrand.Delete(new Brand {Id = 2});

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "-" + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            Indexing();

            Console.WriteLine("----------Added Car------------");

            EfCarDal addNewCarDal = new EfCarDal();
            addNewCarDal.Add(new Car
            {
                Description = "Honda-Civic",
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
