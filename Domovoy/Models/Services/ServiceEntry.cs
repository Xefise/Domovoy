namespace Domovoy.Models;

public class ServiceEntry<T> where T: ServiceBase
{
    public int Id { get; set; }
    public T Service { get; set; }
    public string Data { get; set; }
    public bool Completed { get; set; }
    
    public ApplicationUser? User { get; set; }
    public Apartment? Apartment { get; set; }
}

public class ServiceEntryDTO<T> where T: ServiceBase
{
    public int Id { get; set; }
    public T Service { get; set; }
    public string Data { get; set; }
    public bool Completed { get; set; }
    
    public ApplicationUserViewModel? User { get; set; }
    public ApartmentViewModel? Apartment { get; set; }
}