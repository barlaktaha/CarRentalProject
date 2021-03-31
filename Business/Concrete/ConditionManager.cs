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
    public class ConditionManager : IConditionService
    {
        IConditionDal _conditionDal;

        public ConditionManager(IConditionDal conditionDal)
        {
            _conditionDal = conditionDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IConditionService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Condition condition)
        {
            _conditionDal.Add(condition);
            return new SuccessResult(Messages.ConditionAdded);
        }

        [CacheRemoveAspect("IConditionService.Get")]
        public IResult Delete(Condition condition)
        {
            Condition result = _conditionDal.Get(c => c.ConditionId == condition.ConditionId);
            _conditionDal.Delete(result);
            return new SuccessResult(Messages.ConditionDeleted);

        }

        [CacheAspect]
        public IDataResult<List<Condition>> GetAll()
        {
            return new SuccessDataResult<List<Condition>>(_conditionDal.GetAll());
        }

        [CacheRemoveAspect("IConditionService.Get")]
        public IResult Update(Condition condition)
        {
            Condition result = _conditionDal.Get(c => c.ConditionId == condition.ConditionId);
            _conditionDal.Update(result);
            return new SuccessResult(Messages.ConditionUpdated);

        }
    }
}
