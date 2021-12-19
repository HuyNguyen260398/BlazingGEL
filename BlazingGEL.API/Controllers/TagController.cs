using AutoMapper;
using BlazingGEL.API.Dtos;
using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazingGEL.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagRepository _tagRepo;
    private readonly IMapper _mapper;

    public TagController(ITagRepository tagRepo, IMapper mapper)
    {
        _tagRepo = tagRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTags()
    {
        try
        {
            var tags = await _tagRepo.GetAllAsync();
            var tagsDto = _mapper.Map<IEnumerable<TagDto>>(tags);
            return Ok(tagsDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(int id)
    {
        try
        {
            var tag = await _tagRepo.GetByIdAsync(id);

            if (tag == null)
                return NotFound();

            var tagDto = _mapper.Map<TagDto>(tag);
            return Ok(tagDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag([FromBody] TagDto tagDto)
    {
        try
        {
            if (tagDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = _mapper.Map<Tag>(tagDto);
            var isSuccess = await _tagRepo.CreateAsync(tag);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return Created("CreateTag", new { tag });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTag([FromBody] TagDto tagDto)
    {
        try
        {
            if (tagDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = _mapper.Map<Tag>(tagDto);
            var isSuccess = await _tagRepo.UpdateAsync(tag);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        try
        {
            if (id < 0)
                return BadRequest();

            var isSuccess = await _tagRepo.DeleteAsync(id);

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
