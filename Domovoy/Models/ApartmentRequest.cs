namespace Domovoy.Models;

public class ApartmentRequest
{
    public int Id { get; set; }
    
    public string AdditionalContacts { get; set; }
    
    public ApplicationUser Requester { get; set; }
    public int RequesterId { get; set; }
    
    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }
}

public class ApartmentRequestDTO
{
    public int Id { get; set; }
    
    public string AdditionalContacts { get; set; }
    
    public ApplicationUserViewModel Requester { get; set; }

    public ApartmentViewModel Apartment { get; set; }
}