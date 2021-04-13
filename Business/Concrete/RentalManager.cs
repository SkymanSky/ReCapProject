using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == Id), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CarId == carId), Messages.RentalListedByBrand);
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CustomerId == customerId), Messages.RentalListedByColor);
        }

        public IResult Add(Rental rental)
        {
            IDataResult<List<Rental>> result = CheckReturnDate(rental.CarId);
            if (!result.Success) return new ErrorResult(result.Message);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRented);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<Rental>> CheckReturnDate(int carId)
        {
            List<Rental> result = _rentalDal.GetAll(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0) return new ErrorDataResult<List<Rental>>(Messages.NotRentableCar);
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }
    }
}
