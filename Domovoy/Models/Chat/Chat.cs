namespace Domovoy.Models;

public class Chat
{
    public Chat(){}
    public Chat(string? name, List<ApplicationUser> users, ApplicationUser? administrator)
    {
        Name = name;
        Users = users;
        Administrator = administrator;
        AdministratorId = administrator.Id;
    }

    public Chat(ApartmentHouse apartmentHouse)
    {
        Name = apartmentHouse.ToString();
        ApartmentHouse = apartmentHouse;
        ApartmentHouseId = apartmentHouse.Id;
    }
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ApartmentHouseId { get; set; }
    public ApartmentHouse? ApartmentHouse { get; set; }
    public int? AdministratorId { get; set; }
    public ApplicationUser? Administrator { get; set; }

    public List<ApplicationUser> Users { get; set; }
    public List<Message> Messages { get; set; }
}