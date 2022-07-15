namespace Domovoy.Models;

public class HouseEntrance
{
    public int Id { get; set; }
    
    public int EnranceNumber { get; set; }
    
    public ApartmentHouse ApartmentHouse { get; set; }
    public int ApartmentHouseId { get; set; }
    public List<Apartment> Apartments { get; set; }
}


public class HouseEntranceViewModel
{
    public int Id { get; set; }
    
    public int EnranceNumber { get; set; }
    
    public ApartmentHouseViewModel ApartmentHouse { get; set; }
}

public class HouseEntranceDetails
{
    public int Id { get; set; }
    
    public int EnranceNumber { get; set; }
    
    public List<ApartmentDetails> Apartments { get; set; }
}

public class HouseEntranceCreate
{
    public int EnranceNumber { get; set; }
    
    public int ApartmentHouseId { get; set; }
}

