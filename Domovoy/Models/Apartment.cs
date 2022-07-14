namespace Domovoy.Models;

public class Apartment
{
    public int Id { get; set; }
    
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int Area { get; set; }
    
    public List<ApplicationUser> Tenants { get; set; }
    public ApplicationUser? Owner { get; set; }
    
    public List<ApplicationUser> TenantsWhoMainThis { get; set; }

    public int? Cost { get; set; }

    public HouseEntrance HouseEntrance { get; set; }
}