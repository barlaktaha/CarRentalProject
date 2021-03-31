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
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IModelService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(Messages.ModelAdded);
        }
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Delete(Model model)
        {
            Model result = _modelDal.Get(m => m.ModelId == model.ModelId);
            _modelDal.Delete(result);
            return new SuccessResult(Messages.ModelDeleted);

        }
        [CacheAspect]
        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Update(Model model)
        {
            Model result = _modelDal.Get(m => m.ModelId == model.ModelId);
            _modelDal.Update(result);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
