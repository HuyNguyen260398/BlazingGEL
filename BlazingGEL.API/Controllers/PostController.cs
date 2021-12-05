using AutoMapper;
using BlazingGEL.API.Dtos;
using BlazingGEL.API.Services;
using BlazingGEL.CoreBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazingGEL.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepo;
    private readonly IMapper _mapper;

    public PostController(IPostRepository postRepo, IMapper mapper)
    {
        _postRepo = postRepo;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostDto postDto)
    {
        try
        {
            if (postDto == null) 
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = _mapper.Map<Post>(postDto);
            var isSuccess = await _postRepo.CreatePost(post);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return Created("CreatePost", new { post });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        try
        {
            var posts = await _postRepo.GetAllPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsDto);
        }
        catch (Exception e)
        {
            return StatusCode(500 , e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        try
        {
            var post = await _postRepo.GetPostById(id);

            if (post == null) 
                return NotFound();

            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePost([FromBody] PostDto postDto)
    {
        try
        {
            if (postDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = _mapper.Map<Post>(postDto);
            var isSuccess = await _postRepo.UpdatePost(post);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        try
        {
            if (id < 1)
                return BadRequest();

            var isSuccess = await _postRepo.DeletePost(id);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
