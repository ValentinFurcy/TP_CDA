using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TPVehicule.Tools.ConsoleHelper;
using Entities;
using static System.Console;
using System.Text.Json;
using System.Diagnostics;

namespace TPVehicule.Tools
{
    public static class VehicleHelper
    {
        public static void GetAllVehicles()
        {
            var vehicles = ListVehicles.vehicles.ToList();
            if (vehicles.Any())
            {
                foreach (var v in vehicles)
                {
                    WriteLine(v.ToString());
                }
            }
            else WriteLine("Aucun véhicules trouvé");
        }

        public static void GetVehicleByNumber(string vehicleNumber)
        {
            var v = ListVehicles.vehicles.FirstOrDefault(v => v.Numero == vehicleNumber);

            if (v != null)
            {
                WriteLine(v.ToString());
            }
            else WriteLine("Aucun véhicule trouvé sous ce numéros");
        }

        public static void GetVehicleOrderByMarque()
        {
            var vehicles = ListVehicles.vehicles.OrderBy(v => v.Marque).ToList();
            if (vehicles.Any())
            {
                foreach (var v in vehicles)
                {
                    if (v is Car car)
                    {
                        WriteLine($"voiture : {car.ToString()}");
                    }
                    else if (v is Truck truck)
                    {
                        WriteLine($"camion : {truck.ToString()}");
                    }
                }
            }
            else WriteLine("Aucun véhicule à afficher");
        }

        public static void GetVehicleOrderByMarqueDesc()
        {
            var vehicles = ListVehicles.vehicles.OrderByDescending(v => v.Marque).ToList();
            if (vehicles.Any())
            {
                foreach (var v in vehicles)
                {
                    if (v is Car car)
                    {
                        WriteLine($"voiture : {car.ToString()}");
                    }
                    else if (v is Truck truck)
                    {
                        WriteLine($"camion : {truck.ToString()}");
                    }
                }
            }
            else WriteLine("Aucun véhicule à afficher");
        }

        public static void GetVehicleOrderByModele()
        {
            var vehicles = ListVehicles.vehicles.OrderBy(v => v.Modele).ToList();
            if (vehicles.Any())
            {
                foreach (var v in vehicles)
                {
                    if (v is Car car)
                    {
                        WriteLine($"voiture : {car.ToString()}");
                    }
                    else if (v is Truck truck)
                    {
                        WriteLine($"camion : {truck.ToString()}");
                    }
                }
            }
            else WriteLine("Aucun véhicule à afficher");
        }

        public static void GetVehicleOrderByModeleDesc()
        {
            var vehicles = ListVehicles.vehicles.OrderByDescending(v => v.Modele).ToList();
            if (vehicles.Any())
            {
                foreach (var v in vehicles)
                {
                    if (v is Car car)
                    {
                        WriteLine($"voiture : {car.ToString()}");
                    }
                    else if (v is Truck truck)
                    {
                        WriteLine($"camion : {truck.ToString()}");
                    }
                }
            }
            else WriteLine("Aucun véhicule à afficher");
        }

        public static void GetVehicleGroupByType()
        {
            var vehicules = ListVehicles.vehicles.GroupBy(v => v.GetType().Name).ToList();

            if (vehicules.Any())
            {
                foreach (var group in vehicules)
                {
                    WriteLine($"Type de véhicule : {group.Key}");
                    foreach (var v in group)
                    {
                        WriteLine(v.ToString());
                    }
                    WriteLine();
                }
            }
        }

        public static void SerializerVehicles()
        {
            var vehicles = ListVehicles.vehicles;

            if (vehicles.Any())
            {
                var fileName = "vehicles.json";
                var jsonString = JsonSerializer.Serialize(vehicles);
                File.WriteAllText(fileName, jsonString);
                if (File.Exists(fileName)) WriteLine($"fichier {fileName}  créé avec succès ! !");
                else WriteLine($"echec de la sérialisation du fichier {fileName}");
            }
        }

        public static List<Vehicle> DeserializerVehicles()
        {

            if (!File.Exists("vehicles.json"))
            {
                WriteLine("le fichier n'existe pas");
            }

            var fileContent = File.ReadAllText("vehicles.json");
            var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(fileContent);
            return ListVehicles.vehicles = vehicles;

        }
    }
}
