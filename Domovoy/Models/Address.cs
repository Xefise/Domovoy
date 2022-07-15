namespace Domovoy.Models;

public class Address
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }

    // Строение
    public int? Building { get; set; }

    // Район
    public string? District { get; set; }
    // Корпус
    public int? Housing { get; set; }
}