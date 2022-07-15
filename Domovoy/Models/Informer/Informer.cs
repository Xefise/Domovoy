namespace Domovoy.Models;

public class Informer
{
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime LastInform { get; set; }
    // Is working
    public bool IsActive { get; set; }

    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }

    public int? InformMeterId { get; set; }
    public InformMeter? InformMeter { get; set; }
    public int? EventInformerId { get; set; }
    public EventInformer? EventInformer { get; set; }
}