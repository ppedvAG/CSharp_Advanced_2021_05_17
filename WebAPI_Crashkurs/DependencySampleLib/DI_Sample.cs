using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencySampleLib.GoodSample
{
    public interface ICar
    {
        public string Brandt { get; set; }
        public string Type { get; set; }
        public DateTime ConstructYear { get; set; }
    }

    public interface ICarService
    {
        void RepairCar(ICar car);
    }


    public class Car : ICar // 5 Tage
    {
        public string Brandt { get; set; }
        public string Type { get; set; }
        public DateTime ConstructYear { get; set; }
    }

    public class CarService : ICarService // 3 Tage
    {
        public void RepairCar(ICar car)
        {
            //Mach was
        }
    }


    public class MockCar : ICar
    {
        public string Brandt { get; set; } = "VW";
        public string Type { get; set; } = "Polo";
        public DateTime ConstructYear { get; set; } = DateTime.Now;
    }

    public class Implementierung
    {
        public void ImplementSample ()
        {
            //Beispiel einer losen Kopplung. 
            ICarService carService = new CarService();
            carService.RepairCar(new MockCar()); //Zu Testzwecken
            carService.RepairCar(new Car()); // Eigentliche Implementierung
        }
    }
}
