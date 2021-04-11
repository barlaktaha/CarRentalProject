using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {

            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);


        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car entity)
        {
            Car result = _carDal.Get(c => c.CarId == entity.CarId);
            _carDal.Delete(result);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {
            Car result = _carDal.Get(c=> c.CarId == entity.CarId);
            _carDal.Update(result);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(b => b.BrandId == brandId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(d => min <= d.DailyPrice && d.DailyPrice <= max), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllByBrand(string brandName)
        { 
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=> c.BrandName == brandName), Messages.CarListed);
        }
        public IDataResult<List<CarDetailDto>> GetAllByColor(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == colorName), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarIdDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId), Messages.CarListed);
        }
    }
}
