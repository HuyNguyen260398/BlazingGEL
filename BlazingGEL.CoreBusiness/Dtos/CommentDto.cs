using System.ComponentModel.DataAnnotations;

namespace BlazingGEL.CoreBusiness.Dtos;

public class CommentDto
{
    [Key]
    public int CommentId { get; set; }

    public int PostId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }
}
