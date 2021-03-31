using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId);
            _colorDal.Delete(result);
            return new SuccessResult(Messages.ColorDeleted);

        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            Color result = _colorDal.Get(c => c.ColorId == color.ColorId);
            _colorDal.Update(result);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
