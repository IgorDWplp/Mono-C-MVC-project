using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Project.Service.Models
{
   public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public virtual DbSet<VehicleMake> vehicleMakes { get; set; }
        public virtual DbSet<VehicleModel> vehicleModels { get; set; }

        /// <summary>
        /// Kreiramo bazu i podatke koji su nam potrebni s time da ovverdie virtual OnModelCrating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();   
        }
    }
}
