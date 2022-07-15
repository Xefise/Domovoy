namespace Domovoy.Models;

public class InviteCode
{
    public int Id { get; set; }
    public string Code { get; set; }
    public Apartment Apartment { get; set; }
}

public class InviteCodeViewModel
{
    public int Id { get; set; }
    public string Code { get; set; }
}