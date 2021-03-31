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
    public class GearManager : IGearService
    {
        IGearDal _gearDal;

        public GearManager(IGearDal gearDal)
        {
            _gearDal = gearDal;
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IGearService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Gear gear)
        {
            _gearDal.Add(gear);
            return new SuccessResult(Messages.GearAdded);
        }
        [CacheRemoveAspect("IGearService.Get")]
        public IResult Delete(Gear gear)
        {
            Gear result = _gearDal.Get(g => g.GearId == gear.GearId);
            _gearDal.Delete(result);
            return new SuccessResult(Messages.GearDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Gear>> GetAll()
        {
            return new SuccessDataResult<List<Gear>>(_gearDal.GetAll());
            
        }
        [CacheRemoveAspect("IGearService.Get")]
        public IResult Update(Gear gear)
        {
            Gear result = _gearDal.Get(g => g.GearId == gear.GearId);
            _gearDal.Update(result);
            return new SuccessResult(Messages.GearUpdated);
        }
    }
}
