using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Category category)
        {
            Category result = _categoryDal.Get(c => c.CategoryId == category.CategoryId);
            _categoryDal.Delete(result);
            return new SuccessResult(Messages.CategoryDeleted);
        }


        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
            
        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            Category result = _categoryDal.Get(c => c.CategoryId == category.CategoryId);
            _categoryDal.Update(result);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
