using AutoMapper;
using Planner.Shared.Models;
using Planner.DAL.Tables;
using Microsoft.AspNetCore.Identity;

namespace Planner.BLL.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Region, RegionDTO>();
            CreateMap<RegionDTO, Region>();

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<District, DistrictDTO>();
            CreateMap<DistrictDTO, District>();

            CreateMap<BuildingObject, ObjectDTO>();
            CreateMap<ObjectDTO, BuildingObject>();

            CreateMap<BuildingObject, ObjectDetailDTO>();
            CreateMap<ObjectDetailDTO, BuildingObject>();

            CreateMap<ObjectStatus, ObjectStatusDTO>();
            CreateMap<ObjectStatusDTO, ObjectStatus>();

            CreateMap<ObjectPartnerMap, ObjectPartnerMapDTO>();
            CreateMap<ObjectPartnerMapDTO, ObjectPartnerMap>();

            CreateMap<UserInfo, UserDTO>();
            CreateMap<UserDTO, UserInfo>();

            CreateMap<TaskCard, CardDTO>();
            CreateMap<CardDTO, TaskCard>();

            CreateMap<TaskCard, CreateCardDTO>();
            CreateMap<CreateCardDTO, TaskCard>();

            CreateMap<TaskCard, TaskCardShortInfoDTO>();
            CreateMap<TaskCardShortInfoDTO, TaskCard>();

            CreateMap<TaskStatus, StatusDTO>();
            CreateMap<StatusDTO, TaskStatus>();

            CreateMap<TaskUserMap, TaskUserMapDTO>();
            CreateMap<TaskUserMapDTO, TaskUserMap>();

            CreateMap<AttachFile, FileDTO>();
            CreateMap<FileDTO, AttachFile>();

            CreateMap<FileType, FileTypeDTO>();
            CreateMap<FileTypeDTO, FileType>();

            CreateMap<FileMap, FileMapDTO>();
            CreateMap<FileMapDTO, FileMap>();

            CreateMap<FileExtension, FileExtensionDTO>();
            CreateMap<FileExtensionDTO, FileExtension>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<AreaProperty, AreaPropertyDTO>();
            CreateMap<AreaPropertyDTO, AreaProperty>();

            CreateMap<BuildingObject, DisplayObjectDTO>();
            CreateMap<DisplayObjectDTO, BuildingObject>();

            CreateMap<BuildingObject, ActualBuildingObjectTree>();
            CreateMap<ActualBuildingObjectTree, BuildingObject>();

            CreateMap<District, DistrictWithObjectsTree>();
            CreateMap<DistrictWithObjectsTree, District>();

            CreateMap<ApplicationUser, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUser>();

            CreateMap<IdentityRole, RoleDTO>();
            CreateMap<RoleDTO, IdentityRole>();

            CreateMap<TaskColor, TaskColorDTO>();
            CreateMap<TaskColorDTO, TaskColor>();
        }
    }
}
