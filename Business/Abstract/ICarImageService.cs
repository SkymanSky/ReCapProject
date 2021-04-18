using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage carImage, IFormFile file);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage, IFormFile file);
    }
}
