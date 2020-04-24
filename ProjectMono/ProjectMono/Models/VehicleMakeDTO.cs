using System.Collections.Generic;

namespace ProjectMono
{

    public class VehicleMakeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<VehicleModelDTO> vehicleModels { get; set; }

    }
}