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
                new VehicleMake() { Id = 1, Name = "BMW Group", Abrv = "bmw"},
                new VehicleMake() { Id = 2, Name = "Mercedes-Benz company", Abrv = "Mercedes" },
                new VehicleMake() { Id = 3, Name = "Toyota motor", Abrv = "toyota" },
                new VehicleMake() { Id = 4, Name = "Mazda motor", Abrv = "mazda" },
                new VehicleMake() { Id = 5, Name = "Lexus - Rekusasu", Abrv = "lexus" }
                );
            #region import-migration with enums 
            //modelBuilder.Entity<VehicleModel>().HasData(
            //   new VehicleModel() { Id =1, Name = "Mazda CX-5 2020", Abrv="CX-5", MakeId=Make_ID.MAZDA},
            //   new VehicleModel() { Id =2, Name = "Mazda RX-8", Abrv = "RX-8", MakeId = Make_ID.MAZDA},
            //   new VehicleModel() { Id =3, Name = "Lexus GX", Abrv = "GX", MakeId = Make_ID.LEXUS},
            //   new VehicleModel() { Id =4, Name = "GR Supra", Abrv = "Supra", MakeId = Make_ID.TOYOTA},
            //   new VehicleModel() { Id =5, Name = "Mercedes-Benz SL-klasa", Abrv = "SL", MakeId = Make_ID.MERCEDES},
            //   new VehicleModel() { Id =6, Name = "BMW serija 4 Coupe", Abrv = "BMW 4C", MakeId = Make_ID.BMW}
            //    );
            #endregion
        }

    }
}
