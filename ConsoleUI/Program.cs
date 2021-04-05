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
            Console.WriteLine("-------GetAll-InMemory----------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Id:{3} -Car Description:{0} - Car Model Year:{1} - Car Daily Price:{2}", car.Description,car.ModelYear,car.DailyPrice, car.CarId);
            }

            Console.WriteLine("-------GetById:2----------");

            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine("Car Id:{3} -Car Description:{0} - Car Model Year:{1} - Car Daily Price:{2}", car.Description, car.ModelYear, car.DailyPrice, car.CarId);
            }

            
            InMemoryCarDal updatedCarDal= new InMemoryCarDal();
            updatedCarDal.Add(new Car { CarId = 6, BrandId = "4", ColorId = "3", DailyPrice = 2.45, Description = "Alfa Romeo-Gulietta", ModelYear = "1987" });

            Console.WriteLine("-------New Car Added----------");

            CarManager carManagerUpdated = new CarManager(updatedCarDal);
            foreach (var car in carManagerUpdated.GetAll())
            {
                Console.WriteLine("Car Id:{3} -Car Description:{0} - Car Model Year:{1} - Car Daily Price:{2}", car.Description, car.ModelYear, car.DailyPrice, car.CarId);
            }

            Console.WriteLine("-------Existing Car Deleted----------");

            Car deletedCar = new Car();
            deletedCar.CarId = 3;
            updatedCarDal.Delete(deletedCar);
            CarManager carManagerUpdated2 = new CarManager(updatedCarDal);
            foreach (var car in carManagerUpdated2.GetAll())
            {
                Console.WriteLine("Car Id:{3} -Car Description:{0} - Car Model Year:{1} - Car Daily Price:{2}", car.Description, car.ModelYear, car.DailyPrice, car.CarId);
            }

            Console.WriteLine("-------Existing Car Updated----------");
            Car updatedCar = new Car{  CarId = 6, ModelYear = "2019" };
            
            updatedCarDal.Update(updatedCar);
            foreach (var car in carManagerUpdated2.GetAll())
            {
                Console.WriteLine("Car Id:{3} - Car Description:{0} - Car Model Year:{1} - Car Daily Price:{2}", car.Description, car.ModelYear, car.DailyPrice,car.CarId);
            }

        }
    }
}
