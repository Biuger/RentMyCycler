using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RerservesController : ControllerBase
{
    private readonly IReserveService _reserveService;
    
    public RerservesController(IReserveRepository reserveRepository, IReserveService reserveService)
    {
        _reserveService = reserveService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Reserves>>>> GetAll()
    {
        var response = new Response<List<ReserveDto>>
        {
            Data = await _reserveService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Reserves>>> Post([FromBody] ReserveDto reserveDto)
    {
        var response = new Response<ReserveDto>
        {
            Data = await _reserveService.SaveAsync(reserveDto)
        };

        
       
        return Created($"/api/[controller]/{reserveDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ReserveDto>>> GetById(int id)
    {
        var response = new Response<ReserveDto>();
        
        
        if (!await _reserveService.ReserveExist(id))
        {
            response.Errors.Add("Reservation Not Found");
            return NotFound(response);
        }

        response.Data = await _reserveService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<ReserveDto>>> Update(int id, [FromBody] ReserveDto reserveDto)
    {
        var response = new Response<ReserveDto>();
        if (!await _reserveService.ReserveExist(id))
        {
            response.Errors.Add("Reservation not found");
            return NotFound(response);
        }

        reserveDto.id = id; // Actualizamos el ID con el valor recibido en la ruta
        response.Data = await _reserveService.UpdateAsync(reserveDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _reserveService.ReserveExist(id))
        {
            response.Errors.Add("Reservation not found");
            return NotFound(response);
        }

        var deleted = await _reserveService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete the reservation");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

