using TPVehicule.Tools;
using static System.Console;
using static TPVehicule.Tools.ConsoleHelper;
using static TPVehicule.CRUDCar;
using static TPVehicule.CRUDTruck;
using static TPVehicule.Tools.VehicleHelper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

void choiceMenu()
{
    WriteLine("Quelle action ? ");
    WriteLine("1 - Créer une voiture");
    WriteLine("2 - Créer un camion");
    WriteLine("3 - Voir tout les véhicules");
    WriteLine("4 - Voir un véhicule");
    WriteLine("5 - Modifier une voiture");
    WriteLine("6 - Modifier un camion");
    WriteLine("7 - Supprimer un véhicule");
    WriteLine("8 - Trier les véhicules");
    WriteLine("9 - Filtrer les véhicules");
    WriteLine("10 - Sauvegarder les véhicules");
    WriteLine("11 - Importer les véhicules");
    WriteLine("0 - Sortir du programme\n");
}
void app()
{
    choiceMenu();
    var choix = GetIntFromConsole("Saisir la valeur du choix de l'action ");

    while (choix != 0)
    {
        switch (choix)
        {
            case 1:
                try
                {
                    CreateCar();
                }
                catch (Exception e)
                {
                    WriteLine($"ERREUR : {e.Message} ");
                }
                break;
            case 2:
                try
                {
                    CreateTruck();
                }
                catch (Exception e)
                {
                    WriteLine($"ERREUR : {e.Message} ");
                }
                break;
            case 3:
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Voici les voitures : \n");
                ForegroundColor = ConsoleColor.Green;
                GetAllCars();
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Voici les camions : \n");
                ForegroundColor = ConsoleColor.Blue;
                GetAllTrucks();
                WriteLine();
                ForegroundColor = ConsoleColor.White;
                break;
            case 4:
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Voici les voitures : \n");
                ForegroundColor = ConsoleColor.Green;
                GetAllCars();
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Voici les camions : \n");
                ForegroundColor = ConsoleColor.Blue;
                GetAllTrucks();
                WriteLine();
                ForegroundColor = ConsoleColor.White;
                var vehicleNumber = GetStringFromConsole("saisir le numéros du véhicule");
                try
                {
                    if (vehicleNumber.VerifInputNumberVehicle()) GetVehicleByNumber(vehicleNumber);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
                break;
            case 5:
                UpdateCar();
                break;
            case 6:
                UpdateTruck();
                break;
            case 7:
                var vehiculeToDelete = GetStringFromConsole("quel type de véhicule supprimer ? voiture => v  / camion => c");
                if (!string.IsNullOrEmpty(vehiculeToDelete))
                {
                    if (vehiculeToDelete.ToLower().Equals("v"))
                    {
                        GetAllCars();
                        var numCar = GetStringFromConsole("saisir le numéro de la voiture a supprimer");
                        try
                        {
                            if (numCar.VerifInputNumberVehicle())
                            {
                                var confirm = GetStringFromConsole($"Etes vous sur de vouloir supprimer le véhicule n° : {numCar} (o / n)");
                                if (confirm.ToLower().Equals("o")) DeleteCar(numCar);
                                else WriteLine("Suppression annulée. Le véhicule n'a pas été supprimé.");
                            }
                        }
                        catch (Exception e)
                        {
                            WriteLine(e.Message);
                        }

                    }
                    else if (vehiculeToDelete.ToLower().Equals("c"))
                    {
                        GetAllTrucks();
                        var numTruck = GetStringFromConsole("saisir le numéro du camion a supprimer");
                        try
                        {
                            if (numTruck.VerifInputNumberVehicle())
                            {
                                var confirm = GetStringFromConsole($"Etes vous sur de vouloir supprimer le véhicule n° : {numTruck} (o / n)");
                                if (confirm.ToLower().Equals("o")) DeleteTruck(numTruck);
                                else WriteLine("Suppression annulée. Le véhicule n'a pas été supprimé.");
                            }
                        }
                        catch (Exception e)
                        {
                            WriteLine(e.Message);
                        }
                    }
                    else WriteLine("saisie incorrect");
                }
                else WriteLine("saisie incorrect");
                break;
            case 8:
                WriteLine("Quelle tri effectuer ? ");
                WriteLine("1 - Par marque A-Z");
                WriteLine("2 - Par marque Z-A");
                WriteLine("3 - Par modéle A-Z ");
                WriteLine("4 - Par modéle Z-A");
                WriteLine("5 - Les voitures Par marque A-Z");
                WriteLine("6 - Les camion Par marque A-Z");
                WriteLine("7 - Les voitures et ensuite les camions");
                var choiceTri = GetIntFromConsole("saisir la valeur du choix du tri");
                if (choiceTri != null)
                {
                    switch (choiceTri)
                    {
                        case 1:
                            GetVehicleOrderByMarque();
                            break;
                        case 2:
                            GetVehicleOrderByMarqueDesc();
                            break;
                        case 3:
                            GetVehicleOrderByModele();
                            break;
                        case 4:
                            GetVehicleOrderByModeleDesc();
                            break;
                        case 5:
                            GetCarOrderByMarque();
                            break;
                        case 6:
                            GetTruckOrderByMarque();
                            break;
                        case 7:
                            GetVehicleGroupByType();
                            break;
                    }
                }
                else WriteLine("veuillez saisir une valeur");
                break;
            case 9:
                WriteLine("Quelle filtre effectuer ? ");
                WriteLine("1 - Par marque");
                WriteLine("2 - Par modéle");
                WriteLine("3 - Afficher les voitures avec une puissance <= 120");
                WriteLine("4 - Afficher les voitures avec une puissance > 120");
                WriteLine("5 - Afficher les camions avec un poids < 2000");
                WriteLine("6 - Afficher les camions avec un poids > 2000");
                WriteLine();
                var choiceFilter = GetIntFromConsole("saisir la valeur du choix du tri");
                if (choiceFilter != null)
                {
                    switch (choiceFilter)
                    {
                        case 1:
                            GetAllMarqueVehicle();
                            var marque = GetStringFromConsole("saisir la marque");
                            GetVehicleByMarque(marque);
                            break;
                        case 2:
                            var modele = GetStringFromConsole("saisir le modele");
                            GetVehicleByModele(modele);
                            break;
                        case 3:
                            GetCarByPuissanceInf(120);
                            break;
                        case 4:
                            GetCarByPuissanceSup(120);
                            break;
                        case 5:
                            GetTruckByPoidsInf(2000);
                            break;
                        case 6:
                            GetTruckByPoidsSup(2000);
                            break;
                        default:
                            WriteLine("choix invalide");
                            break;
                    }
                }
                else WriteLine("veuillez saisir une valeur");
                break;
            case 10:
                SerializerVehicles();
                break;
            case 11:
                DeserializerVehicles();
                break;
            default:
                break;
        }

        choiceMenu();
        choix = GetIntFromConsole("Saisir la valeur du choix de l'action ");

    }

    ExitConsoleApp();

}
app();