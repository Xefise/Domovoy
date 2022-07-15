namespace Domovoy.Models;

public class ResidentialComplex
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ConstructionCompany ConstructionCompany { get; set; }
    public List<ApartmentHouse> ApartmentHouses { get; set; }
}

public class ResidentialComplexViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ConstructionCompanyViewModel ConstructionCompany { get; set; }
}

public class ResidentialComplexDetails
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public List<ApartmentHouseDetails> ApartmentHouses { get; set; }
}

public class ResidentialComplexCreate
{
    public string Name { get; set; }
}