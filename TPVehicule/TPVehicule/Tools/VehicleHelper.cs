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
            else WriteLine("erreur lors de la récupération des véhicules");
        }

        public static void GetAllMarqueVehicle()
        {
            var listMarque = ListVehicles.vehicles.Select(v => v.Marque).ToList();

            if (listMarque.Any())
            {
                foreach (var marque in listMarque)
                {
                    WriteLine(marque);
                }
            }
            else WriteLine("pas de marque trouvé");
        }

        /// <summary>
        /// Affiche les véhicules de la marque demandé
        /// </summary>
        /// <param name="marque"></param>
        public static void GetVehicleByMarque(string marque)
        {
            var listVehicle = ListVehicles.vehicles.Where(v => v.Marque.ToLower() == marque.ToLower()).ToList();

            if (listVehicle.Any())
            {
                foreach (var v in listVehicle)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(v.ToString());
                    ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("pas de marque trouvé");
                ForegroundColor = ConsoleColor.White;
            }             
        }

        public static void GetVehicleByModele(string modele)
        {
            var listVehicle = ListVehicles.vehicles.Where(v => v.Modele.ToLower() == modele.ToLower()).ToList();

            if (listVehicle.Any())
            {
                foreach (var v in listVehicle)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(v.ToString());
                    ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("pas de véhicule trouvé");
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// affiche les voitures qui ont une puissance inférieur ou égale a la saisie
        /// </summary>
        /// <param name="puissance"></param>
        public static void GetCarByPuissanceInf(int puissance)
        {
            var listVehicle = ListVehicles.vehicles.Where(v => v is Car && ((Car)v).Puissance <= puissance).OrderBy(v => ((Car)v).Puissance).ToList();

            if (listVehicle.Any())
            {
                foreach (var v in listVehicle)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(v.ToString());
                    ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("pas de véhicule trouvé");
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// affiche les voitures qui ont une puissance supérieur a la saisie
        /// </summary>
        /// <param name="puissance"></param>
        public static void GetCarByPuissanceSup(int puissance)
        {
            var listCars = ListVehicles.vehicles.Where(v => v is Car && ((Car)v).Puissance > puissance).OrderBy(v => ((Car)v).Puissance).ToList();

            if (listCars.Any())
            {
                foreach (var c in listCars)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(c.ToString());
                    ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("pas de véhicule trouvé");
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// affiche les camions qui ont un poids inférieur ou égale a la saisie
        /// </summary>
        /// <param name="poids"></param>
        public static void GetTruckByPoidsInf(int poids) 
        {
            var listTrucks = ListVehicles.vehicles.Where(v => v is Truck && ((Truck)v).Poids <= poids).OrderBy(v => ((Truck)v).Poids).ToList();
            if (listTrucks.Any())
            {
                foreach (var t in listTrucks)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(t.ToString());
                    ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("pas de véhicule trouvé");
                ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// affiche les camions qui ont un poids supérieur a la saisie
        /// </summary>
        /// <param name="poids"></param>
        public static void GetTruckByPoidsSup(int poids)
        {
            var listTrucks = ListVehicles.vehicles.Where(v => v is Truck && ((Truck)v).Poids > poids).OrderBy(v => ((Truck)v).Poids).ToList();
            if (listTrucks.Any())
            {
                foreach (var t in listTrucks)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(t.ToString());
                    ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("pas de véhicule trouvé");
                ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// vérifie si le numéro du véhicule correspond aux attentes => entre 4 et 6 caractères numériques
        /// </summary>
        /// <param name="numVehicle"></param>
        /// <returns>true si OK</returns>
        /// <exception cref="Exception"></exception>
        public static bool VerifInputNumberVehicle(this string numVehicle)
        {
            if (!string.IsNullOrEmpty(numVehicle) && numVehicle.Length >= 4 && numVehicle.Length <= 6)
            {
                bool isValid = true;

                foreach (char c in numVehicle)
                {
                    if (!char.IsDigit(c))
                    {
                        isValid = false;
                        break;
                    }
                }
                return isValid ? true : throw new Exception("Le numéros doit contenir entre 4 et 6 caratères numériques uniquement");
            }
            else throw new Exception("Le numéros doit contenir entre 4 et 6 caratères numériques");
        }

        /// <summary>
        /// vérifie si un véhicule existe déjà avec le numéros du véhicule saisie
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns>false si existe pas</returns>
        /// <exception cref="Exception"></exception>
        public static bool VehicleIsExist(this string vehicleNumber)
        {
            var v = ListVehicles.vehicles.Any(v => v.Numero == vehicleNumber);

            return v ? throw new Exception("Un véhicule contient déjà ce numéros, il doit être unique") : false;

        }

        /// <summary>
        /// serialise la liste de vehicule en format json => vehicles.json
        /// </summary>
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


        /// <summary>
        /// deserialise la liste de vehicule en format json => vehicles.json
        /// </summary>
        public static List<Vehicle> DeserializerVehicles()
        {

            if (!File.Exists("vehicles.json"))
            {
                WriteLine("le fichier n'existe pas");
            }

            var fileContent = File.ReadAllText("vehicles.json");
            var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(fileContent);
            ForegroundColor = ConsoleColor.Green;
            WriteLine("fichier importé avec succès");
            ForegroundColor = ConsoleColor.White;
            return ListVehicles.vehicles = vehicles;

        }
    }
}
