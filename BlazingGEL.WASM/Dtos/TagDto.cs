using System.ComponentModel.DataAnnotations;

namespace BlazingGEL.WASM.Dtos;

public class TagDto
{
    [Key]
    public int TagId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Slug { get; set; }
}
