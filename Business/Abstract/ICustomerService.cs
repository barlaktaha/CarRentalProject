using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer entity);
        IResult Delete(Customer entity);
        IResult Update(Customer entity);
    }
}
