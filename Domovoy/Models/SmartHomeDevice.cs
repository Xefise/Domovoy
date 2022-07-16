using Domovoy.SmartHome;

namespace Domovoy.Models;

public class SmartHomeDevice
{
    public int Id { get; set; }
    
    public SmartHomeDeviceType SmartHomeDeviceType { get; set; }
    
    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }
    public List<SmartHomeDeviceActionLogEntry> ActionLogEntries { get; set; }
}

public enum SmartHomeDeviceType
{
    Intercom
}

public class SmartHomeDeviceDTO
{
    public int Id { get; set; }
    
    public SmartHomeDeviceType SmartHomeDeviceType { get; set; }
    public List<ISmartHomeDeviceAction> Actions { get; set; } 

    public int ApartmentId { get; set; }
}

public class SmartHomeDeviceGet
{
    public int Id { get; set; }
    
    public SmartHomeDeviceType SmartHomeDeviceType { get; set; }

    public int ApartmentId { get; set; }
}

public class SmartHomeDeviceCreate
{
    public SmartHomeDeviceType SmartHomeDeviceType { get; set; }
}