namespace Domovoy.Models;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; }
    // Ready -> false (closed)
    public bool IsActive { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? CloseDate { get; set; }

    public List<ServicePaymentInvoice> ServicePaymentInvoices { get; set; }

    public decimal Debt
    {
        get
        {
            decimal sum = 0;
            foreach (var payment in ServicePaymentInvoices)
            {
                if (!payment.IsPaid) sum += payment.Amount;
            }

            return sum;
        }
    }

    public PermanentService? PermanentService { get; set; }
    public int? PermanentServiceId { get; set; }

    public ServiceUser? ServiceUser { get; set; }
    public int? ServiceUserId { get; set; }
    public ServiceApartment? ServiceApartment { get; set; }
    public int? ServiceApartmentId { get; set; }
}

public class ServiceUser
{
    public int Id { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public int ApplicationUserId { get; set; }
}

public class ServiceApartment
{
    public int Id { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }

    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }
}

public class PermanentService
{
    public int Id { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }

    public bool AutoPay { get; set; }
    public string Period { get; set; }
}