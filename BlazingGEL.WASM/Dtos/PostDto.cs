using System.ComponentModel.DataAnnotations;

namespace BlazingGEL.WASM.Dtos;

public class PostDto
{
    [Required]
    public int PostId { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public string? Slug { get; set; }

    public string? Thumbnail { get; set; }

    [Required]
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime PublishedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Views { get; set; }

    public int Comments { get; set; }
}
