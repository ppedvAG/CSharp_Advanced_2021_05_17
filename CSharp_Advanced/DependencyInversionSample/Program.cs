using System;

namespace DependencyInversionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();
            ICar testCar = new MockCar();
            carService.RepairCar(testCar); //Testen MockCar

            ICar car = new Car();
            car.Brand = "Porsche";
            car.Model = "911";
            car.ConstructionYear = DateTime.Now;
            carService.RepairCar(car);
        }
    }

    #region BadCode (8Tage Arbeit noch nichts getestet)
    public class BadCar // Programmierer A: 5 Tage
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class ElectroCar : BadCar
    {
        public bool IsBatteryFull { get; set; }
    }

    public class BadCarService //Programmierer B: 3 Tage
    {
        public void RepairCar(Car car)
        {
            //Mach was
        }
    }
    #endregion


    #region Bessere Version
    public interface ICar
    {
         string Brand { get; set; }
         string Model { get; set; }
         DateTime ConstructionYear { get; set; }
    }

    public interface ICarService
    {
        public void RepairCar(ICar car);
    }


    //Programmierer A benötigt 5 Tage
    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    //Programmierer B benötigt 3 Tage
    public class CarService : ICarService
    {
        public void RepairCar(ICar car)
        {
            //Repariere ICar
        }
    }


    //Mock-Objekte sind Testobjekt
    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "POLO";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
    }
    #endregion  


}
