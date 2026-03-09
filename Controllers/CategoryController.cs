using Microsoft.AspNetCore.Mvc;
using PersonalFinance.API.DTOs;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public IActionResult Add([FromBody] CreateCategoryDto dto)
        {
            var category = new Category(dto.Name, dto.UserId);
            Result result = _categoryService.Add(category);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            Result result = _categoryService.Remove(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateCategoryDto dto)
        {
            var category = new Category(dto.Name, dto.UserId);
            Result result = _categoryService.Update(id, category);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result<Category?> result = _categoryService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Result<List<Category>> result = _categoryService.GetAll();
            return Ok(result.Value);
        }
    }
}
