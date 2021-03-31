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
    public class FuelManager : IFuelService
    {
        IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IFuelService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Fuel fuel)
        {
            _fuelDal.Add(fuel);
            return new SuccessResult(Messages.FuelAdded);
        }
        [CacheRemoveAspect("IFuelService.Get")]
        public IResult Delete(Fuel fuel)
        {
            Fuel result = _fuelDal.Get(f => f.FuelId == fuel.FuelId);
            _fuelDal.Delete(result);
            return new SuccessResult(Messages.FuelDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Fuel>> GetAll()
        {
            return new SuccessDataResult<List<Fuel>>(_fuelDal.GetAll());
        }
        [CacheRemoveAspect("IFuelService.Get")]
        public IResult Update(Fuel fuel)
        {
            Fuel result = _fuelDal.Get(f => f.FuelId == fuel.FuelId);
            _fuelDal.Update(result);
            return new SuccessResult(Messages.FuelUpdated);
        }
    }
}
