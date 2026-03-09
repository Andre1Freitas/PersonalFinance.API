using Microsoft.AspNetCore.Mvc;
using PersonalFinance.API.DTOs;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateUserDto dto)
        {
            var user = new User(dto.Name, dto.Age, dto.Email);
            Result result = _userService.Add(user);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            Result result = _userService.Remove(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            var user = new User(dto.Name, dto.Age, dto.Email);
            Result result = _userService.Update(id, user);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result<User> result = _userService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Result<List<User>> result = _userService.GetAll();
            return Ok(result.Value);
        }
    }
}
