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
    public class SegmentManager : ISegmentService
    {
        ISegmentDal _segmentDal;

        public SegmentManager(ISegmentDal segmentDal)
        {
            _segmentDal = segmentDal;
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ISegmentService.Get")]
        [TransactionScopeAspect]
        [CacheAspect]
        public IResult Add(Segment segment)
        {
            _segmentDal.Add(segment);
            return new SuccessResult(Messages.SegmentAdded);
        }
        [CacheRemoveAspect("ISegmentService.Get")]
        public IResult Delete(Segment segment)
        {
            Segment result = _segmentDal.Get(s => s.SegmentId == segment.SegmentId);
            _segmentDal.Delete(result);
            return new SuccessResult(Messages.SegmentDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Segment>> GetAll()
        {
            return new SuccessDataResult<List<Segment>>(_segmentDal.GetAll());
        }
        [CacheRemoveAspect("ISegmentService.Get")]
        public IResult Update(Segment segment)
        {
            Segment result = _segmentDal.Get(s => s.SegmentId == segment.SegmentId);
            _segmentDal.Update(result);
            return new SuccessResult(Messages.SegmentUpdated);
        }
    }
}
