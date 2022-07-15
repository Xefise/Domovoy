namespace Domovoy.Models;

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