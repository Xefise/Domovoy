namespace Domovoy.Models;

public class ApartmentHouse
{
    public int Id { get; set; }
    
    public Address Address { get; set; }
    
    public List<HouseEntrance> HouseEntrances { get; set; }
    public ResidentialComplex ResidentialComplex { get; set; }
    public int ResidentialComplexId { get; set; }
}

public class ApartmentHouseViewModel
{
    public int Id { get; set; }
    
    public Address Address { get; set; }
    
    public ResidentialComplexViewModel ResidentialComplex { get; set; }
}

public class ApartmentHouseDetails
{
    public int Id { get; set; }
    
    public Address Address { get; set; }
}

public class ApartmentHouseCreate
{
    public Address Address { get; set; }
    
    public int ResidentialComplexId { get; set; }
}