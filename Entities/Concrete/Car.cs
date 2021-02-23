using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int FuelId { get; set; }
        public int GearId { get; set; }
        public int ConditionId { get; set; }
        public int SegmentId { get; set; }
        public int ModelId { get; set; }
        public int DailyPrice { get; set; }
    }
}
