using AutoMapper;
using Project.Service.Models;
using Project.Service;
using Microsoft.Extensions.Options;

namespace ProjectMono.Models
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<VehicleMake, VehicleMakeDTO>();
            CreateMap<VehicleModel, VehicleModelDTO>();
            CreateMap<VehicleModel, VehicleModelDTO>(MemberList.Source).ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<VehicleModel, VehicleModelDTO>().ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
