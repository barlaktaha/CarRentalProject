using Business.Abstract;
using Business.Constans;
using Core.Entities.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded);
    }

        public IResult Update(Rental entity)
        {
            Rental result = _rentalDal.Get(r => r.RentalId == entity.RentalId);
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalUpdated);

        }
    }
}
