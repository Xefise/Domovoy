using Domovoy.Data;
using Domovoy.Models;

namespace Domovoy.SmartHome;

public interface ISmartHomeDeviceHandler
{
    public SmartHomeDeviceType SmartHomeDeviceType { get; }
    
    public List<ISmartHomeDeviceAction> Actions { get; }
}

public interface ISmartHomeDeviceAction
{
    public string Name { get; }
    public string ActionId { get; }

    public Task Perform(SmartHomeDevice device, ApplicationDbContext db);
}