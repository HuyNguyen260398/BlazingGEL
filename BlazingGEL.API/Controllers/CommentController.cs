using AutoMapper;
using BlazingGEL.CoreBusiness.Dtos;
using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazingGEL.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepo;
    private readonly IMapper _mapper;

    public CommentController(ICommentRepository commentRepo, IMapper mapper)
    {
        _commentRepo = commentRepo;
        _mapper = mapper;
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetByPostId(int postId)
    {
        try
        {
            var comments = await _commentRepo.GetByPostAsync(postId);

            if (comments == null || comments.Count() == 0)
                return NotFound();

            var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return Ok(commentsDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentDto commentDto)
    {
        try
        {
            if (commentDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = _mapper.Map<Comment>(commentDto);
            var isSuccess = await _commentRepo.CreateAsync(comment);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return Created("CreateComment", new { comment });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CommentDto commentDto)
    {
        try
        {
            if (commentDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = _mapper.Map<Comment>(commentDto);
            var isSuccess = await _commentRepo.UpdateAsync(comment);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
