using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TPCodeFirst.ConsoleHelper;
using Repository;
using static System.Console;
using static TPCodeFirst.CRUDLocation;
using Microsoft.EntityFrameworkCore;

namespace TPCodeFirst
{
    public static class CRUDClient
    {
        
        public static void CreateClient() 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            Client client = new Client
            {
                FirstName = GetStringFromConsole("saisir le nom"),
                LastName = GetStringFromConsole("sasir le prenom"),
                DateNaissance = DateOnly.Parse(GetStringFromConsole("saisir la date de naissance YYYY-MM-DD"))
                
            };

            context.Clients.Add(client);
            context.SaveChanges();

        }

        public static void GetAllClient() 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var clients = context.Clients.ToList();

            foreach (var c in clients)
            {
                WriteLine(c.ToString());
            }
        }

        public static async Task GetClientById(int idClient) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var client = await context.Clients.FindAsync(idClient);

            WriteLine(client.ToString());
        }

        public static async Task GetClientAndLoc(int idClient) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var client = await context.Clients.Where(c => c.Id == idClient).Include(c => c.Location).FirstOrDefaultAsync();

            WriteLine(client.ToString());
        }
        public static async void GetClientByName(string firstName, string lastName) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var client = await context.Clients.Where(c => c.FirstName == firstName && c.LastName == lastName).FirstOrDefaultAsync();

            WriteLine(client.ToString());
        }

        public static async Task GetClientByOrderDesc()
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var clients = await context.Clients.OrderByDescending(c => c.FirstName).ToListAsync();

            foreach (var c in clients)
            {
                WriteLine(c.ToString());
            }
        }
        public static async Task GetClientByOrderAsc()
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var clients = await context.Clients.OrderBy(c => c.FirstName).ToListAsync();

            foreach (var c in clients)
            {
                WriteLine(c.ToString());
            }
        }

        public static void UpdateClient(Client paramClient) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            var client = context.Clients.Where(c => c.Id == paramClient.Id).ExecuteUpdate(

                updates => updates.SetProperty(c => c.FirstName, paramClient.FirstName).SetProperty(c => c.LastName, paramClient.LastName)
                
                );

            if (client > 0)
            {
                WriteLine("Mise à jour OK");
                GetClientById(paramClient.Id);
            }
            else WriteLine("Echec");
        }
        
        public static async Task DeleteClient(int idClient) 
        {
            LocationCodeFirstContext context = new LocationCodeFirstContext();

            List<Location> loc = await GetLocationByIdClientAsync(idClient);

            foreach (var l in loc)
            {
                DeletedLocationAsync(l.Id);
            }

            var clientDeleted = await context.Clients.Where(c => c.Id == idClient).ExecuteDeleteAsync();

            if (clientDeleted > 0) { WriteLine("Sup OK"); }
            else WriteLine("Echec");
        }
    }
}
