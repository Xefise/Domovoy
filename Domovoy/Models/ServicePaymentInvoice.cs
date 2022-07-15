namespace Domovoy.Models;

public class ServicePaymentInvoice
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }

    public decimal Amount { get; set; }
    public string Check { get; set; }
    public bool IsPaid { get; set; }
    // DeadLine
    public DateTime RepaymentTime { get; set; }
}