using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileSystems;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(
                CheckIfCarImageCountOfCarCorrect(carImage.CarId));
            if (result != null) return result;

            carImage.ImagePath = new FileManagerOnDisk().Add(file, CreateNewPath(file));
            carImage.ImageUploadDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Araba Resmi Eklendi");
           
        }

        public IResult Delete(CarImage carImage)
        {
            new FileManagerOnDisk().Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Araba Resmi Silindi.");
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            IfCarImageOfCarNotExistsAddDefault(result, carId);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i=>i.Id==id));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var carImageToUpdate = _carImageDal.Get(i=>i.CarId==carImage.CarId);
            carImage.CarId = carImageToUpdate.CarId;
            carImage.Id = carImageToUpdate.Id;
            carImage.ImagePath = new FileManagerOnDisk().Update(carImageToUpdate.ImagePath, file, CreateNewPath(file));
            carImage.ImageUploadDate=DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult("Araç resmi güncellendi.");
        }

        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);

            var newPath =
                $@"{Environment.CurrentDirectory}\Public\CarImages\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }
        private IResult CheckIfCarImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5) return new ErrorResult(Messages.CarImageCountOfCarError);
            return new SuccessResult();
        }

        private void IfCarImageOfCarNotExistsAddDefault(List<CarImage> result, int carId)
        {
            if (!result.Any())
            {
                var defaultCarImage = new CarImage
                {
                    CarId = carId,
                    ImagePath =
                        $@"{Environment.CurrentDirectory}\Public\CarImages\default-img.jpg",
                    ImageUploadDate = DateTime.Now
                };
                result.Add(defaultCarImage);
            }
        }
    }
}
