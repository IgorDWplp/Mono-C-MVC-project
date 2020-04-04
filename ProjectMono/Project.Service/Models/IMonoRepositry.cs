using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Models
{
   public interface IMonoRepositry
    {
        IEnumerable<VehicleMake> GetAllVehicleMakes();

        IEnumerable<VehicleModel> GetAllVehicleModels();
        VehicleMake GetVehicle(int id);
        VehicleMake UpdateVehicleMake(VehicleMake vehicleMakeChanges);
        VehicleMake AddNew(VehicleMake vehicle);
        VehicleMake Delete(int id);
    }
}
