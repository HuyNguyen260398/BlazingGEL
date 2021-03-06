using System.ComponentModel.DataAnnotations;

namespace BlazingGEL.WASM.Dtos;

public class CategoryDto
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Slug { get; set; }
}
