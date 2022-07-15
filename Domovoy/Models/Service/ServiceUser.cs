namespace Domovoy.Models;

public class ServiceUser
{
    public int Id { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public int ApplicationUserId { get; set; }
}