using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RentalHistoryController : ControllerBase
{
    private readonly IRentalHistoryService _rentalHistoryService;
    
    public RentalHistoryController(IRentalHistoryRepository rentalHistoryRepository, IRentalHistoryService rentalHistoryService)
    {
        _rentalHistoryService = rentalHistoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<RentalHistory>>>> GetAll()
    {
        var response = new Response<List<RentalHistoryDto>>
        {
            Data = await _rentalHistoryService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<RentalHistory>>> Post([FromBody] RentalHistoryDto rentalHistoryDto)
    {
        var response = new Response<RentalHistoryDto>
        {
            Data = await _rentalHistoryService.SaveAsync(rentalHistoryDto)
        };

        
       
        return Created($"/api/[controller]/{rentalHistoryDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<RentalHistoryDto>>> GetById(int id)
    {
        var response = new Response<RentalHistoryDto>();
        
        
        if (!await _rentalHistoryService.RentalHistoryExist(id))
        {
            response.Errors.Add("Rental History Not Found");
            return NotFound(response);
        }

        response.Data = await _rentalHistoryService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<RentalHistoryDto>>> Update(int id, [FromBody] RentalHistoryDto rentalHistoryDto)
    {
        var response = new Response<RentalHistoryDto>();
        if (!await _rentalHistoryService.RentalHistoryExist(id))
        {
            response.Errors.Add("Rental History not found");
            return NotFound(response);
        }

        rentalHistoryDto.id = id; // Actualizamos el ID con el valor recibido en la ruta
        response.Data = await _rentalHistoryService.UpdateAsync(rentalHistoryDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _rentalHistoryService.RentalHistoryExist(id))
        {
            response.Errors.Add("Rental History not found");
            return NotFound(response);
        }

        var deleted = await _rentalHistoryService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete Rental History");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

