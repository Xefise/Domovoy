namespace Domovoy.Models;

public class Chat
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ApartmentHouseId { get; set; }
    public ApartmentHouse? ApartmentHouse { get; set; }
    public int? AdministratorId { get; set; }
    public ApplicationUser Administrator { get; set; }

    public List<ApplicationUser> Users { get; set; }
    public List<Message> Messages { get; set; }
}