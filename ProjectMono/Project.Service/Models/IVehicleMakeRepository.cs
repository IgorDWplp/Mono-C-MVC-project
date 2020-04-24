using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
   public interface IVehicleMakeRepository
    {
        //Vehicle make
        IEnumerable<VehicleMake> GetAllVehicleMakes();
        Task<VehicleMake> GetVehicle(int id);
        Task<VehicleMake> UpdateVehicleMake(VehicleMake vehicleMakeChanges);
        Task<VehicleMake> AddNew(VehicleMake vehicle);
        Task<VehicleMake> Delete(int id);
    }
}
