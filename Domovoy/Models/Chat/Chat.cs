namespace Domovoy.Models;

public class Chat
{
    public Chat(){}
    public Chat(string? name, List<ApplicationUser> users)
    {
        Name = name;
        Users = users;
    }
    public Chat(ApartmentHouse house)
    {
        ApartmentHouse = house;
        //ApartmentHouseId = house.Id;
    }
    public int Id { get; set; }

    public string Name { get; set; }

    public ApartmentHouse? ApartmentHouse { get; set; }
    public int? AdministratorId { get; set; }
    public ApplicationUser? Administrator { get; set; }

    public List<ApplicationUser> Users { get; set; }
    public List<Message> Messages { get; set; }
}