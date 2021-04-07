﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        //List<Car> GetById(int carId);
        List<Car>GetCarsByBrandId(string brandId);
        List<Car> GetCarsByColorId(string colorId);

    }
}
