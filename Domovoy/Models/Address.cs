namespace Domovoy.Models;

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public int HouseNumber { get; set; }
    
    // Строение
    public int? Building { get; set; }
    
    // Корпус
    public int? Housing { get; set; }
}