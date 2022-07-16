using AutoMapper;
using Domovoy.Models;
using Domovoy.SmartHome;
using Microsoft.AspNetCore.JsonPatch;

namespace Domovoy.Mapping;

public class AppMappingProfile : Profile
{
    public AppMappingProfile(IServiceProvider provider)
    {
        CreateMap<ApplicationUser, ApplicationUserViewModel>();
        CreateMap<Apartment, ApartmentViewModel>();
        CreateMap<HouseEntrance, HouseEntranceViewModel>();
        CreateMap<ConstructionCompany, ConstructionCompanyViewModel>();
        CreateMap<ApartmentHouse, ApartmentHouseViewModel>();
        CreateMap<ResidentialComplex, ResidentialComplexViewModel>();
        CreateMap<InviteCode, InviteCodeViewModel>();
        CreateMap<ApartmentRequest, ApartmentRequestDTO>();

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
        CreateMap<ApartmentPutTenant, Apartment>();

        CreateMap<SmartHomeDeviceActionLogEntry, SmartHomeDeviceActionLogEntryDTO>();
        CreateMap<SmartHomeDevice, SmartHomeDeviceGet>();
        CreateMap<SmartHomeDevice, SmartHomeDeviceDTO>()
            .ForMember(
                d => d.Actions,
                c => c.MapFrom(device =>
                    provider.GetServices<ISmartHomeDeviceHandler>()
                        .First(h => h.SmartHomeDeviceType == device.SmartHomeDeviceType).Actions));
    }
}