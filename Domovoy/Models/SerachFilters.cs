namespace Domovoy.Models;

public class SerachFilters
{
    public string City { get; set; }
    public ApartmentType? ApartmentType { get; set; }
    public ApartmentState? ApartmentState { get; set; }
    public int CostMin { get; set; }
    public int CostMax { get; set; }
    public int RoomCountMin { get; set; }
    public int RoomCountMax { get; set; }
}