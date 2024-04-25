using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BikesController : ControllerBase
{
    private readonly IBikeService _bikeService;
    
    public BikesController(IBikeRepository bikeRepository, IBikeService bikeService)
    {
        _bikeService = bikeService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Bikes>>>> GetAll()
    {
        var response = new Response<List<BikeDto>>
        {
            Data = await _bikeService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Bikes>>> Post([FromBody] BikeDto bikeDto)
    {
        var response = new Response<BikeDto>
        {
            Data = await _bikeService.SaveAsync(bikeDto)
        };

        
       
        return Created($"/api/[controller]/{bikeDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BikeDto>>> GetById(int id)
    {
        var response = new Response<BikeDto>();
        
        
        if (!await _bikeService.BikeExist(id))
        {
            response.Errors.Add("Bike Not Found");
            return NotFound(response);
        }

        response.Data = await _bikeService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<BikeDto>>> Update(int id, [FromBody] BikeDto bikeDto)
    {
        var response = new Response<BikeDto>();
        if (!await _bikeService.BikeExist(id))
        {
            response.Errors.Add("Bike not found");
            return NotFound(response);
        }

        bikeDto.id = id; // Actualizamos el ID con el valor recibido en la ruta
        response.Data = await _bikeService.UpdateAsync(bikeDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _bikeService.BikeExist(id))
        {
            response.Errors.Add("Bike not found");
            return NotFound(response);
        }

        var deleted = await _bikeService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete bike");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

