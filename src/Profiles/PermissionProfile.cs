using AutoMapper;
using Permissions.API.Entities;
using Permissions.API.Helpers;
using Permissions.API.Models;
using Permissions.API.Resources.Commands;
using System.Linq;

namespace Permissions.API.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile() 
        {
            CreateMap<Permission, PermissionForUpdateDTO>();
            CreateMap<Permission, PermissionForListDTO>()
                .ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(src => src.PermissionDate.ToRelativeDate()));
            CreateMap<PermissionForUpdateDTO, UpdatePermissionCommand>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<PermissionForUpdateDTO, Permission>()
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PermissionTypes, opt => opt.Ignore());
        }
    }
}
