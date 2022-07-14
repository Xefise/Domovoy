using AutoMapper;
using Domovoy.Models;

namespace Domovoy.Mapping;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<ApplicationUser, ApplicationUserViewModel>();
        CreateMap<Apartment, ApartmentViewModel>();
        CreateMap<HouseEntrance, HouseEntranceViewModel>();
        CreateMap<ConstructionCompany, ConstructionCompanyViewModel>();
        CreateMap<ApartmentHouse, ApartmentHouseViewModel>();
    }
}