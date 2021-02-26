using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarList();
            // CarAdded();
            // CarDeleted();


        }

        private static void CarDeleted()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car()
            {
                CarId = 1003,

            };
            carManager.Deleted(car);
        }

        private static void CarAdded()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car()
            {
                CategoryId = 3,
                GearId = 2,
                BrandId = 1,
                ColorId = 3,
                ConditionId = 3,
                FuelId = 4,
                ModelId = 10,
                SegmentId = 3,
                DailyPrice = 0,
            };
            carManager.Add(car);
            
        }

        private static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine
                        (
                        "Marka: " + car.BrandName + "\n" +
                        "Model: " + car.ModelName + "\n" +
                        "Kasa Tipi: " + car.CategoryName + "\n" +
                        "Şanzıman Tipi: " + car.GearName + "\n" +
                        "Renk: " + car.ColorName + "\n" +
                        "Segment: " + car.SegmentName + "\n" +
                        "Yakıt: " + car.FuelName + "\n" +
                        "Kiralama Koşulu: " + car.ConditionName + "\n" +
                        "Günlük Kiralama Ücreti : " + car.DailyPrice + "\n"
                        );

                }
            }
            else
            {
                Console.WriteLine(result.Message);

            }
            
            
        }
    }
}
