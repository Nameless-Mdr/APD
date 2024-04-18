using APD.Domain.Entity;
using APD.Models.DTO.Installation;
using APD.Models.DTO.Office;
using APD.Models.DTO.PrintDevice;
using APD.Models.DTO.User;
using AutoMapper;

namespace APD.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region Mapping User
        CreateMap<User, GetUserModel>()
            .ForMember(d => d.OfficeName, m 
                => m.MapFrom(s => s.Office.Name));
        #endregion

        #region Mapping Office
        CreateMap<Office, GetOfficeModel>();
        #endregion

        #region Mapping Installation
        CreateMap<Installation, GetInstallationModel>()
            .ForMember(d => d.TypeConnectName, m
                => m.MapFrom(s => s.PrintDevice.Name));
        #endregion

        #region MappingPrintDevice
        CreateMap<PrintDevice, GetPrintDeviceModel>()
            .ForMember(d => d.TypeConnect, m
                => m.MapFrom(s => s.TypeConnect.Name));
        #endregion
    }
}