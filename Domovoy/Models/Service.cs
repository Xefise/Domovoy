namespace Domovoy.Models;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; }
    // Ready -> false (closed)
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime CloseDate { get; set; }
    public string Check { get; set; }
    // Оплачено?
    public bool HasPaid { get; set; }

    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }

    public PermanentService? PermanentService { get; set; }
}

public class PermanentService
{
    public int Id { get; set; }
    public Service Service { get; set; }

    public bool AutoPay { get; set; }
    public string Period { get; set; }
}