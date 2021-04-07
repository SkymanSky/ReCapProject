using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        //public List<Car> GetById(int carId)
        //{
        //    return _carDal.GetById(carId).Where(c=>c.CarId==carId).ToList();
        //    _carDal.
        //}

        public List<Car> GetCarsByBrandId(string brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(string colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
