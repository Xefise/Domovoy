namespace Domovoy.Models;

public class Message
{
    public Message(){}
    public Message(string text, Chat chat, ApplicationUser author)
    {
        Text = text;
        ChatId = chat.Id;
        Chat = chat;
        AuthorId = author.Id;
        Author = author;
    }
    public int Id { get; set; }

    public int ChatId { get; set; }
    public Chat Chat { get; set; }

    public string Text { get; set; }
    public DateTime SentAt { get; set; }

    public int AuthorId { get; set; }
    public ApplicationUser Author { get; set; }
}