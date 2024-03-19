using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TPVehicule.Tools.ConsoleHelper;
using Entities;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPVehicule
{
    public static class CRUDTruck
    {
        public static void CreateTruck()
        {
            Truck t = new Truck()
            {
                Marque = GetStringFromConsole("saisir la marque du camion"),
                Modele = GetStringFromConsole("saisir le modéle du camion"),
                Numero = GetStringFromConsole("saisir le numéro du véhicule (longueur comprise entre 4 et 6 charactéres, numérique uniquement)"),
                Poids = GetIntFromConsole("saisir le poids")
            };


            ListVehicles.vehicles.Add(t);

            WriteLine($"camion crée : {t.ToString()}");
        }
        public static void GetAllTrucks()
        {
            var trucks = ListVehicles.vehicles.OfType<Truck>();
            if (trucks.Any())
            {
                foreach (var t in trucks)
                {
                    WriteLine(t.ToString());
                }
            }
            else WriteLine("Aucun camion trouvé");
        }

        public static void GetTruckOrderByMarque()
        {
            var trucks = ListVehicles.vehicles.OrderBy(t => t.Marque).ToList();
            if (trucks.Any())
            {
                foreach (var t in trucks)
                {
                    if (t is Truck truck)
                    {
                        WriteLine($"camion : {truck.ToString()}");
                    }
                }
            }
            else WriteLine("Aucun véhicule à afficher");
        }
        public static void UpdateTruck()
        {
            GetAllTrucks();

            var truckUpd = GetStringFromConsole("saisir le numero du camion à modifier");
            var v = ListVehicles.vehicles.FirstOrDefault(t => t.Numero == truckUpd);

            if (v != null && v is Truck truck)
            {
                WriteLine($"marque actuelle : {v.Marque}");
                v.Marque = GetStringFromConsole("saisir la marque :");
                WriteLine($"modele actuelle : {v.Modele}");
                v.Modele = GetStringFromConsole("saisir le modele :");
                WriteLine($"puissance actuelle : {truck.Poids}");
                truck.Poids = GetIntFromConsole("saisir le poids");

                ForegroundColor = ConsoleColor.Red;
                WriteLine(v.ToString());

                ForegroundColor = ConsoleColor.White;
            }
            else WriteLine("aucune voiture trouvé");
        }

        public static void DeleteTruck(string numTruck )
        {
            var truck = ListVehicles.vehicles.FirstOrDefault(t => t.Numero == numTruck);
            if (truck != null)
            {
                ListVehicles.vehicles.Remove(truck);
                WriteLine("Véhicule supprimé avec succès!");
            }
            else WriteLine("Aucun camion trouvé sous ce numéros");
        }
    }
}
