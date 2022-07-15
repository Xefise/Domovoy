namespace Domovoy.Models;

public class PermanentService
{
    public int Id { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }

    public bool AutoPay { get; set; }
    public string Period { get; set; }
}