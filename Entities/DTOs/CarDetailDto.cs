using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
        public int ModelId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string GearName { get; set; }
        public int GearId { get; set; }
        public string ColorName { get; set; }
        public int ColorId { get; set; }
        public string SegmentName { get; set; }
        public int SegmentId { get; set; }
        public string FuelName { get; set; }
        public int FuelId { get; set; }
        public string ConditionName{ get; set; }
        public int ConditionId { get; set; }
        public string ImagePath { get; set; }
        public int CarImageId { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
    }
}
