namespace Domovoy.Models;

public class Apartment
{
    public int Id { get; set; }
    
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    public int RoomCount { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int LivingArea { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int AreaWithoutBalconies { get; set; }

    public ApartmentType ApartmentType { get; set; }
    public ApartmentState ApartmentState { get; set; }
    public int? Cost { get; set; }
    public string? Description { get; set; }
    
    public List<ApplicationUser> Tenants { get; set; }
    public ApplicationUser? Owner { get; set; }
    
    public List<ApplicationUser> TenantsWhoMainThis { get; set; }
    public List<ApplicationUser> TenantsWhoAddThisToCart { get; set; }
    public List<InviteCode> InviteCodes { get; set; }
    
    public List<SmartHomeDevice> SmartHomeDevices { get; set; }

    public HouseEntrance HouseEntrance { get; set; }
    public int HouseEntranceId { get; set; }
}

public enum ApartmentType
{
    Living,
    Commercial
}

public enum ApartmentState
{
    NotForSell,
    ForSell,
    ForRent,
    Booked
}

public class ApartmentViewModel
{
    public int Id { get; set; }
    
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int LivingArea { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int AreaWithoutBalconies { get; set; }

    public ApartmentType ApartmentType { get; set; }

    public ApartmentState ApartmentState { get; set; }
    public int? Cost { get; set; }
    public string? Description { get; set; }
    
    public List<ApplicationUserViewModel> Tenants { get; set; }
    public ApplicationUserViewModel? Owner { get; set; }
    
    public List<ApplicationUserViewModel> TenantsWhoMainThis { get; set; }

    public HouseEntranceViewModel HouseEntrance { get; set; }
}

public class ApartmentDetails
{
    public int Id { get; set; }
    
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int LivingArea { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int AreaWithoutBalconies { get; set; }

    public ApartmentType ApartmentType { get; set; }

    public ApartmentState ApartmentState { get; set; }
    public int? Cost { get; set; }
    public string? Description { get; set; }
    
    public List<ApplicationUserViewModel> Tenants { get; set; }
    public List<InviteCodeViewModel> InviteCodes { get; set; }
    public ApplicationUserViewModel? Owner { get; set; }
    
    public List<ApplicationUserViewModel> TenantsWhoMainThis { get; set; }
    
    public List<SmartHomeDeviceGet> SmartHomeDevices { get; set; }
}

public class ApartmentCreate
{
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int LivingArea { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int AreaWithoutBalconies { get; set; }

    public ApartmentType ApartmentType { get; set; }

    public ApartmentState ApartmentState { get; set; }
    public int? Cost { get; set; }
    public string? Description { get; set; }
    
    public int HouseEntranceId { get; set; }
}

public class ApartmentPut
{
    public int Id { get; set; }
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int Area { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int LivingArea { get; set; }
    /// <summary>
    /// В кв.м.
    /// </summary>
    public int AreaWithoutBalconies { get; set; }

    public ApartmentType ApartmentType { get; set; }

    public ApartmentState ApartmentState { get; set; }
    public int? Cost { get; set; }
    public string? Description { get; set; }
}

public class ApartmentPutTenant
{
    public int Id { get; set; }
    
    public ApartmentState ApartmentState { get; set; }
    public int? Cost { get; set; }
    public string? Description { get; set; }
}