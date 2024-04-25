using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UsersController(IUserRepository userRepository, IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Users>>>> GetAll()
    {
        var response = new Response<List<UserDto>>
        {
            Data = await _userService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Users>>> Post([FromBody] UserDto UserDto)
    {
        var response = new Response<UserDto>
        {
            Data = await _userService.SaveAsync(UserDto)
        };

        
       
        return Created($"/api/[controller]/{UserDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int id)
    {
        var response = new Response<UserDto>();
        
        
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }

        response.Data = await _userService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> Update(int id, [FromBody] UserDto UserDto)
    {
        var response = new Response<UserDto>();
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User not found");
            return NotFound(response);
        }

        UserDto.id = id; // Actualizamos el ID con el valor recibido en la ruta
        response.Data = await _userService.UpdateAsync(UserDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User not found");
            return NotFound(response);
        }

        var deleted = await _userService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete user");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

