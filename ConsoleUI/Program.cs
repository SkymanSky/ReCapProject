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
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName+"-"+car.ModelName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(result.Message);

        }

    }   
}
