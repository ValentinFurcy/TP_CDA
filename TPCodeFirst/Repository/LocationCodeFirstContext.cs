using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LocationCodeFirstContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=TPCodeFirst;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cli1 = new Client { Id = 1, FirstName = "Durand", LastName = "Olivier", DateNaissance = DateOnly.Parse("20/10/1990") };
            var cli2 = new Client { Id = 2, FirstName = "Dupond", LastName = "Nathan", DateNaissance = DateOnly.Parse("02/12/1993") };
            var cli3 = new Client { Id = 3, FirstName = "Croft", LastName = "Lara", DateNaissance = DateOnly.Parse("20/10/1988") };

            var cat1 = new Category { Id = 1, Label = "Citadine", Price_KM = 50 };
            var cat2 = new Category { Id = 2, Label = "Berline", Price_KM = 80 };

            var m1 = new Marque { Id = 1, Name = "Peugeot" };
            var m2 = new Marque { Id = 2, Name = "Renault" };

            var v1 = new Vehicle { Id = 1, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v2 = new Vehicle { Id = 2, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v3 = new Vehicle { Id = 3, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v4 = new Vehicle { Id = 4, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v5 = new Vehicle { Id = 5, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v6 = new Vehicle { Id = 6, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v7 = new Vehicle { Id = 7, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v8 = new Vehicle { Id = 8, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v9 = new Vehicle { Id = 9, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };
            var v10 = new Vehicle { Id = 10, Color = "Rouge", Model = "208", MarqueId = m1.Id, CategoryId = cat2.Id };


            modelBuilder.Entity<Client>().HasData(cli1);
            modelBuilder.Entity<Client>().HasData(cli2);
            modelBuilder.Entity<Client>().HasData(cli3);
            modelBuilder.Entity<Category>().HasData(cat1);
            modelBuilder.Entity<Category>().HasData(cat2);
            modelBuilder.Entity<Marque>().HasData(m1);
            modelBuilder.Entity<Marque>().HasData(m2);
            modelBuilder.Entity<Vehicle>().HasData(v1);
            modelBuilder.Entity<Vehicle>().HasData(v2);
            modelBuilder.Entity<Vehicle>().HasData(v3);
            modelBuilder.Entity<Vehicle>().HasData(v4);
            modelBuilder.Entity<Vehicle>().HasData(v5);
            modelBuilder.Entity<Vehicle>().HasData(v6);
            modelBuilder.Entity<Vehicle>().HasData(v7);
            modelBuilder.Entity<Vehicle>().HasData(v8);
            modelBuilder.Entity<Vehicle>().HasData(v9);
            modelBuilder.Entity<Vehicle>().HasData(v10);

            base.OnModelCreating(modelBuilder);
        }


    }
}
