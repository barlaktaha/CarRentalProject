using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Delete(Car entity);
        IResult Add(Car entity);
        IResult Update(Car entity);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetAllByBrand(string brandName);
        IDataResult<List<CarDetailDto>> GetAllByColor(string colorName);
        IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarIdDetails(int carId);
    }
}
