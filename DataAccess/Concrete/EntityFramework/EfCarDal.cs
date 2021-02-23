using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             join y in context.Categories
                             on c.CategoryId equals y.CategoryId
                             join g in context.GearType
                             on c.GearId equals g.GearId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             join s in context.Segments
                             on c.SegmentId equals s.SegmentId
                             join f in context.FuelType
                             on c.FuelId equals f.FuelId
                             join n in context.Conditions
                             on c.ConditionId equals n.ConditionId
                             

                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName, ModelName = m.ModelName, CategoryName=y.CategoryName,
                                 GearName = g.GearName, ColorName = r.ColorName, SegmentName = s.SegmentName,
                                 FuelName = f.FuelName, ConditionName = n.ConditionName, DailyPrice = c.DailyPrice,
                             };

                              return result.ToList();
            }
        }
    }
}
