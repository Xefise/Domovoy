using System.ComponentModel.DataAnnotations.Schema;

namespace Domovoy.Models;

public class Informer
{
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime LastInform { get; set; }
    // Is working
    public bool IsActive { get; set; }

    public Apartment Apartment { get; set; }
    public int ApartmentId { get; set; }

    public int? InformMeterId { get; set; }
    public InformMeter? InformMeter { get; set; }
    public int? EventInformerId { get; set; }
    public EventInformer? EventInformer { get; set; }
}

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

public class EventInformer
{
    public int Id { get; set; }
    public Informer Informer { get; set; }
    public int InformertId { get; set; }

    /// <summary>
    /// Активен прямо сейчас
    /// </summary>
    public bool IsNowActive { get; set; }
    public List<ActiveSession> ActiveSessions { get; set; }
    public DateTime? Time { get; set; }
}

public class ActiveSession
{
    public int Id { get; set; }
    public EventInformer EventInformer { get; set; }
    public int EventInformerId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Comment { get; set; }

    [NotMapped] public TimeSpan Duration => End - Start;
}