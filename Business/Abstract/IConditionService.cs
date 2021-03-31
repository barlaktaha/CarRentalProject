using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IConditionService
    {
        IResult Add(Condition condition);
        IResult Delete(Condition condition);
        IResult Update(Condition condition);
        IDataResult<List<Condition>> GetAll();
    }
}
