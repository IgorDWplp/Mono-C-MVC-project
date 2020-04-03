using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Project.Service.Models
{
   public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake() { Id = 1, Name = "BMW", Abrv = "bmw"},
                new VehicleMake() { Id = 2, Name = "Toyota", Abrv = "toyota" }
                );
        }

    }
}
