using Business.Abstract;
using Business.Constans;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult Add(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages carImages)
        {
            FileHelper.Delete(carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImagesDeleted);
            
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), Messages.CarImagesListed);
        }

  

        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = FileHelper.Update(_carImagesDal.Get(p => p.ImagesId == carImages.ImagesId).ImagePath, file);
            carImages.Date = DateTime.Now;
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImagesUpdated);
        }
        public IDataResult<CarImages> Get(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.ImagesId == id));
        }
    }
}
