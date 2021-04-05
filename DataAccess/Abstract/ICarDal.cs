using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car product);
        void Delete(Car product);
        List<Car> GetAllById(int carId);
    }
}
