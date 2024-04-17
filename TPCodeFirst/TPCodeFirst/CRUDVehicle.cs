using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TPCodeFirst.ConsoleHelper;
using static System.Console;
using Entities;
using Repository;
using Microsoft.EntityFrameworkCore;




namespace TPCodeFirst
{
    public class CRUDVehicle
    {
        public static async Task CreateVehicle()
        {
             LocationCodeFirstContext context = new LocationCodeFirstContext();

            Vehicle vehicle = new Vehicle 
            { 
               
            };

        } 

        public static List<Vehicle> GetAllVehicles() 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var vehicles = context.Vehicles.ToList();

            return vehicles;
        }

        public static void UpdateVehicle()
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var vehicles = GetAllVehicles();

            foreach (var v in vehicles)
            {
                WriteLine(v.ToString());
            }
            var immat = Deserialize();

            for (var i = 0; i < vehicles.Count; i++)
            {
                 context.Vehicles.Where(v => v.Id == i+1).ExecuteUpdate(
                    updates => updates.SetProperty(v => v.Immatriculation, immat[i].immat
                    ));

            }
            //for (var i = 0; i < vehicles.Count; i++)
            //{
            //    vehicles[i].Immatriculation = immat[i].immat;               
            //}

            var v2 = GetAllVehicles();

            foreach (var v in v2)
            {
                WriteLine(v.ToString());
            }
          
        }
    }
}
