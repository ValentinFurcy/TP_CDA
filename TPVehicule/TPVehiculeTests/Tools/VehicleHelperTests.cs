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
            VehicleHelper.VehicleIsExist("0001");           
        }

        [TestMethod()]
        public void VehicleIsExistTest()
        {
            
            var isExist = VehicleHelper.VehicleIsExist("0006");

            //Assert
            Assert.AreEqual(false, isExist);

        }
    }
}