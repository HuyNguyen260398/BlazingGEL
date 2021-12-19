using AutoMapper;
using BlazingGEL.API.Dtos;
using BlazingGEL.CoreBusiness.Models;
using BlazingGEL.Services.DataStoreInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazingGEL.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepo;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepo, IMapper mapper)
    {
        _categoryRepo = categoryRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
    {
        try
        {
            if (categoryDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _mapper.Map<Category>(categoryDto);
            var isSuccess = await _categoryRepo.CreateAsync(category);

            if (!isSuccess)
                return StatusCode(500, "Internal Server Error.");

            return Created("CreateCategory", new { category });
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CategoryDto categoryDto)
    {
        try
        {
            if (categoryDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _mapper.Map<Category>(categoryDto);
            var isSuccess = await _categoryRepo.UpdateAsync(category);

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
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (id < 0)
                return BadRequest();

            var isSuccess = await _categoryRepo.DeleteAsync(id);

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
