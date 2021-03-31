using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string CategoryName { get; set; }
        public string GearName { get; set; }
        public string ColorName { get; set; }
        public string SegmentName { get; set; }
        public string FuelName { get; set; }
        public string ConditionName{ get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
    }
}
