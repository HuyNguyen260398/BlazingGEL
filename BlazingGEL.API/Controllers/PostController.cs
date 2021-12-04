using AutoMapper;
using BlazingGEL.API.Dtos;
using BlazingGEL.API.Services;
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

    [HttpGet]
    public async Task<object> GetPosts()
    {
        try
        {
            var posts = await _postRepo.GetPosts();
            IEnumerable<PostDto> postsDto =  _mapper.Map<IEnumerable<PostDto>>(posts); 
            return Ok(posts);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}
