using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPVehicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TPVehicule.Tests
{
    [TestClass()]
    public class CRUDCarTests
    {

        [TestMethod()]
        public void DeleteCarTest()
        {
           
            var vehicleToDelete = ListVehicles.vehicles.FirstOrDefault(v => v.Numero == "0001");

            CRUDCar.DeleteCar(vehicleToDelete.Numero);

            var v = ListVehicles.vehicles.FirstOrDefault(v => v.Numero == "0001");


            Assert.IsNull(v);
        }
    }
}