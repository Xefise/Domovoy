namespace Domovoy.Models;

public class ApartmentService: ServiceBase
{
    public List<ApartmentHouse> ScopeHouses { get; set; }
    public ApartmentServiceType Type { get; set; }
}

public enum ApartmentServiceType
{
    Animals,
    Cleaning
}