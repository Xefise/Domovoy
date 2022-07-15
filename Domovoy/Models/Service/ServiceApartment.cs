namespace Domovoy.Models;

public class ServiceApartment
{
    public int Id { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }

    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }
}
