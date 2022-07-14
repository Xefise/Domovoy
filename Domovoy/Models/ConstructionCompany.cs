namespace Domovoy.Models;

public class ConstructionCompany
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ApplicationUser> Employees { get; set; }
    /// <summary>
    /// If ConstructionCompanyAdmin
    /// </summary>
    public List<ApartmentHouse> ApartmentHouses { get; set; }
}