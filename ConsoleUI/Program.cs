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
            //GetCarDetails();
            //CarAddTest();

            //ColorAddTest();
            //ColorDeleteTest();
            //ColorUpdateTest();
            //ColorGetAll();


            //BrandTest();
            //BrandGetAll();
            //BrandAddTest();
            //BrandDeleteTest();
            //BrandUpdateTest();
        }

        private static void CarAddTest()
        {
            Console.WriteLine("---------Cars---------");
            GetCarDetails();
            Console.WriteLine("---------Added Cars---------");
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 21,
                Description = "Benzin Otomatik",
                ModelYear = "2019",
                ModelName = "Juke"
            });
            GetCarDetails();
        }

        private static void BrandUpdateTest()
        {
            Console.WriteLine("--------Brands------");
            BrandGetAll();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand {Id = 4, BrandName = "Geely"});
            Console.WriteLine("--------Updated Brands------");
            BrandGetAll();
        }

        private static void BrandDeleteTest()
        {
            Console.WriteLine("--------Brands------");
            BrandGetAll();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand {Id = 1002});
            Console.WriteLine("--------After Removing - Brands------");
            BrandGetAll();
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {BrandName = "BMW"});
            BrandGetAll();
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "-" + brand.BrandName);
            }
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "-" + color.ColorName);
            }
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color {Id = 4, ColorName = "Siyah"});
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "-" + color.ColorName);
            }
        }

        private static void ColorDeleteTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color {Id = 5});
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "-" + color.ColorName);
            }
        }

        private static void ColorAddTest()
        {
            ColorManager addNewColor = new ColorManager(new EfColorDal());
            addNewColor.Add(new Color {ColorName = "Black"});

            foreach (var color in addNewColor.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            addNewColor.GetAll();
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "-" + car.ModelName + "-" + car.ColorName + "-" + car.DailyPrice);
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
