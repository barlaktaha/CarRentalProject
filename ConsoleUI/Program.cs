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
                DailyPrice = 450,
            };
            carManager.Add(car);
            Console.WriteLine("Yeni Araba Eklendi.");
        }

        private static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(
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
    }
}
