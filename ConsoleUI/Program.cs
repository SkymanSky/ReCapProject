using Business.Concrete;
using System;
using System.Threading.Channels;
using Core.Utilities.Results;
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
           

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            Rental rental = new Rental
                {CarId = 2006, CustomerId = 1, RentDate = DateTime.Now, RentEndDate = DateTime.Now};
            IResult result = rentalManager.Add(rental);
            if (!result.Success) Console.WriteLine(result.Message);
            if(result.Success) Console.WriteLine(result.Message);

            void CarTest()
            {
                CarManager carManager = new CarManager(new EfCarDal());
                var result = carManager.GetAll();
                if (result.Success == true)
                {
                    foreach (var car in result.Data)
                    {
                        Console.WriteLine(car.BrandId + "-" + car.ModelName);
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
}

