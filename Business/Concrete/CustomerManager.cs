using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
         ICustomerDal _customerDal;

         public CustomerManager(ICustomerDal customerDal)
         {
             _customerDal = customerDal;
         }

         public IResult Add(Customer entity)
         {
             _customerDal.Add(entity);
             return new SuccessResult(Messages.CustomerAdded);
         }

         public IResult Delete(Customer entity)
         {
             Customer result = _customerDal.Get(u => u.CustomerId == entity.CustomerId);
             _customerDal.Delete(result);
             return new SuccessResult(Messages.CustomerDeleted);
         }

         public IResult Update(Customer entity)
         {
             Customer result = _customerDal.Get(u => u.CustomerId == entity.CustomerId);
             _customerDal.Update(result);
             return new SuccessResult(Messages.CustomerUpdated);
         }
        
    }
}
