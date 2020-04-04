using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Service.Models
{
   public class SqlRepositry : IMonoRepositry
    {

        private readonly AppDbContext context;
        public SqlRepositry(AppDbContext context)
        {
            this.context = context;
        }

        #region CRUD operations for VehicleMakes

        public IEnumerable<VehicleMake> GetAllVehicleMakes()
        {
            return context.vehicleMakes;
        }

        public VehicleMake GetVehicle(int id)
        {
            return context.vehicleMakes.Find(id);
        }

        public VehicleMake UpdateVehicleMake(VehicleMake vehicleMakeChanges)
        {
            var vehicle = context.vehicleMakes.Attach(vehicleMakeChanges);
            vehicle.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return vehicleMakeChanges;
        }
        
        public VehicleMake AddNew(VehicleMake vehicle)
        {
            context.Add(vehicle);
            context.SaveChanges();
            return vehicle;
        }

        public VehicleMake Delete(int id)
        {
            VehicleMake vehicle = context.vehicleMakes.Find(id);
            if(vehicle != null)
            {
                context.vehicleMakes.Remove(vehicle);
                context.SaveChanges();
            }

            return vehicle;
        }
        #endregion

        #region CRUD operations for VehicleModels
        public IEnumerable<VehicleModel> GetAllVehicleModels()
        {
            return context.vehicleModels;
        }
        #endregion

    }
}
