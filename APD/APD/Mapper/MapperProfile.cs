using ADP.Constants;
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
            .ForMember(d => d.PrintDeviceName, m
                => m.MapFrom(s => s.PrintDevice.Name))
            .ForMember(d => d.Default, m 
                => m.MapFrom(s => s.IsDefault ? InstallationConstants.DefaultYes : InstallationConstants.DefaultNo))
            .ForMember(d => d.OfficeName, m 
                => m.MapFrom(s => s.Office.Name));

        CreateMap<CreateInstallationModel, Installation>()
            .ForMember(d => d.IsDefault, m 
                => m.MapFrom(s => s.Default == InstallationConstants.DefaultYes));
        #endregion

        #region MappingPrintDevice
        CreateMap<PrintDevice, GetPrintDeviceModel>()
            .ForMember(d => d.TypeConnect, m
                => m.MapFrom(s => s.TypeConnect.Name));
        #endregion
    }
}