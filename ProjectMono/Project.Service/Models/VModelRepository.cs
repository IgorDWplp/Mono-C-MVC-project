using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
   public class VModelRepository : IVehicleModelRepository
    {
        private readonly DbContext context;
        public VModelRepository(DbContext context)
        {
            this.context = context;
        }
 
        public IEnumerable<VehicleModel> GetAllVehicleModels()
        {
            return context.vehicleModels;
        }

        public async Task<VehicleModel> GetModel(int id)
        {
            return await context.vehicleModels.FindAsync(id);
        }

        public async Task<VehicleModel> UpdateVehicleModel(VehicleModel vehicleModelChanges)
        {
            var vehicle = context.vehicleModels.Attach(vehicleModelChanges); //context.vehicleMakes.Attach(vehicleMakeChanges);
            vehicle.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return vehicleModelChanges;
        }

        public async Task<VehicleModel> Delete(int id)
        {
            VehicleModel vehicleModel = await context.vehicleModels.FindAsync(id);

            if (vehicleModel != null)
            {
                context.vehicleModels.Remove(vehicleModel);
                await context.SaveChangesAsync();
            }
            return vehicleModel;
        }

        public async Task<VehicleModel> AddNew(VehicleModel vehicle)
        {
            context.Add(vehicle);
            await context.SaveChangesAsync();
            return vehicle;
        }

        public IQueryable<VehicleModel> GetVehicleModelsIQueryable(IEnumerable<VehicleModel> vehicleModels)
        {
            var VehicleModel = from v in context.vehicleModels
                               select v;
            return VehicleModel;
        }

        public IEnumerable<VehicleMake> GetVehicleMakes()
        {
            return context.vehicleMakes;
        }


    }
}
