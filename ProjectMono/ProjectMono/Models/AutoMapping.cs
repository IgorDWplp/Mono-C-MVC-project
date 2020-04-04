using AutoMapper;
using Project.Service.Models;
using Project.Service;


namespace ProjectMono.Models
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleMake, VehicleMakeDTO>();
        }

        
    }
}
