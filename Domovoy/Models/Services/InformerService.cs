namespace Domovoy.Models;

public class InformerService: ServiceBase
{
    public List<ApartmentHouse> ScopeHouses { get; set; } 
    public InformerServiceType Type { get; set; }
}

public enum InformerServiceType
{
    Water
}