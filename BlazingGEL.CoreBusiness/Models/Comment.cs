namespace BlazingGEL.CoreBusiness.Models;

public class Comment
{
    public int CommentId { get; set; }

    public int PostId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }
}
