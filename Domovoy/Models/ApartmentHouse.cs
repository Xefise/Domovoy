namespace Domovoy.Models;

public class ApartmentHouse
{
    public int Id { get; set; }
    
    public Address Address { get; set; }
    
    public List<HouseEntrance> HouseEntrances { get; set; }
    public ConstructionCompany ConstructionCompany { get; set; }
}

public class ApartmentHouseViewModel
{
    public int Id { get; set; }
    
    public Address Address { get; set; }
    
    public ConstructionCompanyViewModel ConstructionCompany { get; set; }
}