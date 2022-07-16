namespace Domovoy.Models;

public class SmartHomeDeviceActionLogEntry
{
    public int Id { get; set; }
    
    public bool Perfomed { get; set; }
    public DateTime DateTime { get; set; }
    public string ActionId { get; set; }
    
    public SmartHomeDevice SmartHomeDevice { get; set; }
}

public class SmartHomeDeviceActionLogEntryDTO
{
    public int Id { get; set; }
    
    public bool Perfomed { get; set; }
    public DateTime DateTime { get; set; }
    public string ActionId { get; set; }
}