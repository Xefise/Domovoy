namespace Domovoy.Models;

public class ServiceBase
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ApplicationUser SerivceProvider { get; set; }
}