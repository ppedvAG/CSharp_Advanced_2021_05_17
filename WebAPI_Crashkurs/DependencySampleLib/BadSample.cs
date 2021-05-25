using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencySampleLib
{
    // Nachteile -> Car ist mit CarService.RepairCar fest verdrahtet -> Bei Änderungen meist Refactorings
    // 
    public class Car //Programmier benötigt 5 Tage
    {
        public string Brandt { get; set; }
        public string Modell { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class CarService //Programmierer B benötigt 2 Tage
    {
        public void RepairCar(Car car)
        {
            //Repariere Auto 
        }
    }
}
