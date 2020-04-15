using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
   public class SqlRepository : IMonoRepositry
    {
 
        private readonly AppDbContext context;
        public SqlRepository(AppDbContext context)
        {
            this.context = context;
        }

        #region CRUD operations for VehicleMakes

        public IEnumerable<VehicleMake> GetAllVehicleMakes()
        {
            return  context.vehicleMakes;
        }

        public async Task<VehicleMake> GetVehicle(int id)
        {
            return await context.vehicleMakes.FindAsync(id);
        }

        public async Task<VehicleMake> UpdateVehicleMake(VehicleMake vehicleMakeChanges)
        {
            var vehicle = context.vehicleMakes.Attach(vehicleMakeChanges);
            vehicle.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return vehicleMakeChanges;
        }
        
        public async Task<VehicleMake> AddNew(VehicleMake vehicle)
        {
            context.Add(vehicle);
            await context.SaveChangesAsync();
            return  vehicle;
        }

        public async Task<VehicleMake> Delete(int id)
        {
            VehicleMake vehicle = await context.vehicleMakes.FindAsync(id);
            //var vehicle_fk = context.vehicleModels.Where(m => m.MakeId == id).ToList();

            if (vehicle != null)
            {
                //context.Remove(vehicle_fk);
                var commandText = "delete from VehicleModel where MakeId = @id";
                var vehicle_model = new SqlParameter("@id", id);
                context.Database.ExecuteSqlCommand(commandText, vehicle_model);

                context.vehicleMakes.Remove(vehicle);
                await context.SaveChangesAsync();
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
