namespace Domovoy.Models;

public class UserService: ServiceBase
{
    public bool UserMustHaveAnApartment { get; set; }
    public UserServiceType Type { get; set; }
}

public enum UserServiceType
{
    Legal,
    Insurance
}