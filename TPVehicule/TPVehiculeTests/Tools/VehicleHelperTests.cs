using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPVehicule.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TPVehicule.Tools.Tests
{
    [TestClass()]
    public class VehicleHelperTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void VehicleIsExistTestException()
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car {Marque = "Toyota", Modele = "Camry", Numero = "0001", Puissance = 150 },
                new Car { Marque = "Honda", Modele = "Accord", Numero = "0002", Puissance = 180 },
                new Car { Marque = "Peugeot", Modele = "208", Numero = "0003", Puissance = 120 },
                new Car { Marque = "Citroen", Modele = "C4", Numero = "0004", Puissance = 150 },

                new Truck {Marque = "Ford", Modele = "F-150", Numero = "1000", Poids = 2000 },
                new Truck { Marque = "Chevrolet", Modele = "Silverado", Numero = "1001", Poids = 2500 },
                new Truck { Marque = "Volvo", Modele = "camion", Numero = "1002", Poids = 3500 },
                new Truck { Marque = "Nan", Modele = "Camion", Numero = "1003", Poids = 3000 },
            };
              
            VehicleHelper.VehicleIsExist("0001");
                    
        }

        [TestMethod()]
        public void VehicleIsExistTest()
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Car {Marque = "Toyota", Modele = "Camry", Numero = "0001", Puissance = 150 },
                new Car { Marque = "Honda", Modele = "Accord", Numero = "0002", Puissance = 180 },
                new Car { Marque = "Peugeot", Modele = "208", Numero = "0003", Puissance = 120 },
                new Car { Marque = "Citroen", Modele = "C4", Numero = "0004", Puissance = 150 },

                new Truck {Marque = "Ford", Modele = "F-150", Numero = "1000", Poids = 2000 },
                new Truck { Marque = "Chevrolet", Modele = "Silverado", Numero = "1001", Poids = 2500 },
                new Truck { Marque = "Volvo", Modele = "camion", Numero = "1002", Poids = 3500 },
                new Truck { Marque = "Nan", Modele = "Camion", Numero = "1003", Poids = 3000 },
            };

            var v = vehicles.Any(v => v.Numero == "0006");

            //Assert
            Assert.AreEqual(false, v);

        }
    }
}