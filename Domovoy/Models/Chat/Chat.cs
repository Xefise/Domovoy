namespace Domovoy.Models;

public class Chat
{
    public Chat(){}
    public Chat(string? name, List<ApplicationUser> users)
    {
        Name = name;
        Users = users;
    }
    public int Id { get; set; }

    public string Name { get; set; }

    public ApartmentHouse? ApartmentHouse { get; set; }
    public int? AdministratorId { get; set; }
    public ApplicationUser? Administrator { get; set; }

    public List<ApplicationUser> Users { get; set; }
    public List<Message> Messages { get; set; }
}