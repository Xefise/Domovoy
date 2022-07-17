namespace Domovoy.Models;

public class ServiceEntriesCollection
{
    public List<ServiceEntryDTO<UserService>> UserServicesEntries { get; set; }
    public List<ServiceEntryDTO<ApartmentService>> ApartmentServicesEntries { get; set; }
    public List<ServiceEntryDTO<InformerService>> InformerServicesEntries { get; set; } 
}