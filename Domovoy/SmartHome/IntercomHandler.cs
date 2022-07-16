using Domovoy.Data;
using Domovoy.Models;
using Domovoy.SmartHome;

class IntercomHandler: ISmartHomeDeviceHandler
{
    public SmartHomeDeviceType SmartHomeDeviceType => SmartHomeDeviceType.Intercom;

    public List<ISmartHomeDeviceAction> Actions => new()
    {
        new IntercomOpenAction()
    };
}

class IntercomOpenAction : ISmartHomeDeviceAction
{
    public string Name => "Открыть дверь";
    public string ActionId => "open_door";
    
    public async Task Perform(SmartHomeDevice device, ApplicationDbContext db)
    {
        db.SmartHomeDeviceActionLog.Add(new()
        {
            Perfomed = false,
            DateTime = DateTime.Now,
            ActionId = ActionId,
            SmartHomeDevice = device
        });

        await db.SaveChangesAsync();
    }
}