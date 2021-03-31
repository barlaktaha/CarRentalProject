using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISegmentService
    {
        IResult Add(Segment segment);
        IResult Delete(Segment segment);
        IResult Update(Segment segment);
        IDataResult<List<Segment>> GetAll();

    }
}
