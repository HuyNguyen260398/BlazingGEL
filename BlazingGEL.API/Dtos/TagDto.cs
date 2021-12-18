using System.ComponentModel.DataAnnotations;

namespace BlazingGEL.API.Dtos;

public class TagDto
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Slug { get; set; }
}
