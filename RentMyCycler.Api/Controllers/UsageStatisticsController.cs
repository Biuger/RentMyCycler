using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsageStatisticsController : ControllerBase
{
    private readonly IUsageStatisticsService _usageStatisticsService;
    
    public UsageStatisticsController(IUsageStatisticsRepository usageStatisticsRepository, IUsageStatisticsService usageStatisticsService)
    {
        _usageStatisticsService = usageStatisticsService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<UsageStatistics>>>> GetAll()
    {
        var response = new Response<List<UsageStatisticsDto>>
        {
            Data = await _usageStatisticsService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<UsageStatistics>>> Post([FromBody] UsageStatisticsDto usageStatisticsDto)
    {
        var response = new Response<UsageStatisticsDto>
        {
            Data = await _usageStatisticsService.SaveAsync(usageStatisticsDto)
        };

        
       
        return Created($"/api/[controller]/{usageStatisticsDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UsageStatisticsDto>>> GetById(int id)
    {
        var response = new Response<UsageStatisticsDto>();
        
        
        if (!await _usageStatisticsService.UsageStatisticsExist(id))
        {
            response.Errors.Add("Statistics Not Found");
            return NotFound(response);
        }

        response.Data = await _usageStatisticsService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<UsageStatisticsDto>>> Update(int id, [FromBody] UsageStatisticsDto usageStatisticsDto)
    {
        var response = new Response<UsageStatisticsDto>();
        if (!await _usageStatisticsService.UsageStatisticsExist(id))
        {
            response.Errors.Add("Statistics not found");
            return NotFound(response);
        }

        usageStatisticsDto.id = id; // Actualizamos el ID con el valor recibido en la ruta
        response.Data = await _usageStatisticsService.UpdateAsync(usageStatisticsDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _usageStatisticsService.UsageStatisticsExist(id))
        {
            response.Errors.Add("Statistics not found");
            return NotFound(response);
        }

        var deleted = await _usageStatisticsService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete statistics");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

