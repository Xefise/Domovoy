using System.ComponentModel.DataAnnotations.Schema;

namespace Domovoy.Models;

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