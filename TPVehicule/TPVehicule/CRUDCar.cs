using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TPVehicule.Tools.ConsoleHelper;
using Entities;
using static System.Console;

namespace TPVehicule
{
    public static class CRUDCar
    {
      
        public static void CreateCar()
        {
            Car c = new Car()
            {
                Marque = GetStringFromConsole("saisir la marque de la voiture"),
                Modele = GetStringFromConsole("saisir le modéle de la voiture"),
                Numero = GetStringFromConsole("saisir le numéro du véhicule (longueur comprise entre 4 et 6 charactéres, numérique uniquement)"),
                Puissance = GetIntFromConsole("saisir la puissance")
            };

            ListVehicles.vehicles.Add(c);

            WriteLine($"voiture crée : {c.ToString()}");
        }

        public static void GetAllCars()
        {
            var cars = ListVehicles.vehicles.OfType<Car>();
            if (cars.Any())
            {
                foreach (var c in cars)
                {
                    WriteLine(c.ToString());
                }
            }
            else WriteLine("Aucune voiture trouvé");
        }

        public static void GetCarOrderByMarque()
        {
            var cars = ListVehicles.vehicles.OrderBy(c => c.Marque).ToList();
            if (cars.Any())
            {
                foreach (var c in cars)
                {
                    if (c is Car car)
                    {
                        WriteLine($"voiture : {car.ToString()}");
                    }
                }
            }
            else WriteLine("Aucun véhicule à afficher");
        }

        public static void UpdateCar() 
        {
            GetAllCars();

            var carUpd = GetStringFromConsole("saisir le numero de la voiture à modifier");
            var v = ListVehicles.vehicles.FirstOrDefault(c => c.Numero == carUpd);

            if (v != null && v is Car car)
            {
                WriteLine($"marque actuelle : {v.Marque}");
                v.Marque = GetStringFromConsole("saisir la marque :");
                WriteLine($"modele actuelle : {v.Modele}");
                v.Modele = GetStringFromConsole("saisir le modele :");
                WriteLine($"puissance actuelle : {car.Puissance}");
                car.Puissance = GetIntFromConsole("saisir la puissance");

                ForegroundColor = ConsoleColor.Red;
                WriteLine(v.ToString());

                ForegroundColor = ConsoleColor.White;
            }
            else WriteLine("aucune voiture trouvé");
        }

        public static void DeleteCar(string numCar) 
        { 
            var car = ListVehicles.vehicles.FirstOrDefault(c => c.Numero == numCar);
            if (car != null) 
            {
                ListVehicles.vehicles.Remove(car);
                WriteLine("Véhicule supprimé avec succès!");
            }
            else WriteLine("Aucune voiture trouvé sous ce numéros");
        }
    }
}
