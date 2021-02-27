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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User entity)
        {
            User result = _userDal.Get(u => u.UserId == entity.UserId);
            _userDal.Delete(result);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(User entity)
        {
            User result = _userDal.Get(u => u.UserId == entity.UserId);
            _userDal.Update(result);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
