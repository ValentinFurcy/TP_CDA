using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TPCodeFirst.ConsoleHelper;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Repository;





namespace TPCodeFirst
{
    public static class CRUDLocation
    {

        public static void CreateLocationForClient() 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            Location loc = new Location
            {
                Nb_KM = GetIntFromConsole("saisir le nombre de km"),
                Date_Start = DateOnly.Parse(GetStringFromConsole("saisir la date de début (YYYY-MM-DD)")),
                Date_End = DateOnly.Parse(GetStringFromConsole("saisir la date de fin (YYYY-MM-DD)")),
                ClientId = GetIntFromConsole("saisir l'id du client"),
                VehicleId = GetIntFromConsole("saisir l'id du vehicule"),
            };

            context.Locations.Add(loc);
            context.SaveChanges();
        }

        public static async Task CreateLocationAndClientAsync() 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            Client c = new Client 
            {
                FirstName = GetStringFromConsole("saisir le nom"),
                LastName = GetStringFromConsole("sasir le prenom"),
                DateNaissance = DateOnly.Parse(GetStringFromConsole("saisir la date de naissance YYYY-MM-DD"))
            };

            Location loc = new Location
            {
                Nb_KM = GetIntFromConsole("saisir le nombre de km"),
                Date_Start = DateOnly.Parse(GetStringFromConsole("saisir la date de début (YYYY-MM-DD)")),
                Date_End = DateOnly.Parse(GetStringFromConsole("saisir la date de fin (YYYY-MM-DD)")),
                ClientId = c.Id,
                VehicleId = GetIntFromConsole("saisir l'id du vehicule"),
            };

            context.Clients.Add(c);
            context.Locations.Add(loc);

            context.SaveChanges();
        }

        public static async Task GetAllLocationAsync()
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var locations = await context.Locations.ToListAsync();
            WriteLine(locations.ToString());
        }

        public static async Task GetLocationByIdAsync(int idLoc) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var loc = await context.Locations.FindAsync(idLoc);

            WriteLine(loc.ToString());
        }

        public static async Task<List<Location>> GetLocationByIdClientAsync(int idClient)
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var loc = await context.Locations.Where(l => l.ClientId == idClient).ToListAsync();

            WriteLine(loc.ToString());

            return loc;
        }

        public static async Task UpdateLocationAsync(Location loc) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var locToUpd = await context.Locations.Where(l => l.Id == loc.Id).ExecuteUpdateAsync(
                updates => updates.SetProperty(l => l.Date_Start, loc.Date_Start).SetProperty(l => l.Date_End, loc.Date_End).SetProperty(l => l.Nb_KM, loc.Nb_KM));

            if(locToUpd > 0) 
            {
                WriteLine("MaJ OK");
                GetLocationByIdAsync(loc.Id);
            }
        }

        public static async Task DeletedLocationAsync(int idLoc)
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var locToDeleted = await context.Locations.Where(l => l.Id == idLoc).ExecuteDeleteAsync();

            if (locToDeleted > 0) { WriteLine("Sup OK"); }
            else WriteLine("Echec");

        }


    }
}
