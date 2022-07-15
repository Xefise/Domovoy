using AutoMapper;
using Domovoy.Models;
using Microsoft.AspNetCore.JsonPatch;

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
        CreateMap<ResidentialComplex, ResidentialComplexViewModel>();
        
        CreateMap<Apartment, ApartmentDetails>();
        CreateMap<HouseEntrance, HouseEntranceDetails>();
        CreateMap<ConstructionCompany, ConstructionCompanyDetails>();
        CreateMap<ApartmentHouse, ApartmentHouseDetails>();
        CreateMap<ResidentialComplex, ResidentialComplexDetails>();
        
        CreateMap<ResidentialComplexCreate, ResidentialComplex>();
        CreateMap<ApartmentHouseCreate, ApartmentHouse>();
        CreateMap<HouseEntranceCreate, HouseEntrance>();
        CreateMap<ApartmentCreate, Apartment>();
        
        CreateMap<ApartmentPut, Apartment>();
    }
}