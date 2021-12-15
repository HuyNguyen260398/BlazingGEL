using AutoMapper;
using BlazingGEL.API.Dtos;
using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazingGEL.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepo;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;

    public PostController(IPostRepository postRepo, IMapper mapper, IWebHostEnvironment environment)
    {
        _postRepo = postRepo;
        _mapper = mapper;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        try
        {
            var posts = await _postRepo.GetAllAsync();
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
            var post = await _postRepo.GetByIdAsync(id);

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
            var isSuccess = await _postRepo.CreateAsync(post);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return Created("CreatePost", new { post });
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
            var isSuccess = await _postRepo.UpdateAsync(post);

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

            var isSuccess = await _postRepo.DeleteAsync(id);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("[action]")]
    public async Task<string> Save()
    {
        string path = string.Empty;
        if (HttpContext.Request.Form.Files.Any())
        {
            foreach (var file in HttpContext.Request.Form.Files)
            {
                path = Path.Combine(_environment.ContentRootPath, "uploads", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }
        byte[] ByteArray = System.IO.File.ReadAllBytes(path);

        return Convert.ToBase64String(ByteArray);
    }
}
