using APD.Domain.Entity;
using APD.Models.DTO.Office;
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
    }
}