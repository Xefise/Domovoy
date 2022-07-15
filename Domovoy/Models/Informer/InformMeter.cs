namespace Domovoy.Models;

public class InformMeter
{
    public int Id { get; set; }
    public Informer Informer { get; set; }
    public int InformertId { get; set; }

    public int Count { get; set; }
    /// <summary>
    /// Для различных проверок
    /// </summary>
    public int LastInformedCount { get; set; }
}
