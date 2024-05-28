using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BikeCategoriesController : ControllerBase
{
    private readonly IBikeCategoryService _bikeCategoryService;
    
    public BikeCategoriesController(IBikeCategoryRepository bikeCategoryRepository, IBikeCategoryService bikeCategoryService)
    {
        _bikeCategoryService = bikeCategoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<BikeCategories>>>> GetAll()
    {
        var response = new Response<List<BikeCategoryDto>>
        {
            Data = await _bikeCategoryService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<BikeCategories>>> Post([FromBody] BikeCategoryDto bikeCategoryDto)
    {
        var response = new Response<BikeCategoryDto>();

        if (await _bikeCategoryService.ExistByName(bikeCategoryDto.Bike_type))
        {
            response.Errors.Add($"Product Category name {bikeCategoryDto.Bike_type} already exist");
            return BadRequest(response);
        }

        response.Data = await _bikeCategoryService.SaveAsync(bikeCategoryDto);
        
        return Created($"/api/[controller]/{bikeCategoryDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BikeCategoryDto>>> GetById(int id)
    {
        var response = new Response<BikeCategoryDto>();
        
        
        if (!await _bikeCategoryService.BikeCategoryExist(id))
        {
            response.Errors.Add("Bike category Not Found");
            return NotFound(response);
        }

        response.Data = await _bikeCategoryService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut()]
    public async Task<ActionResult<Response<BikeCategoryDto>>> Update(int id, [FromBody] BikeCategoryDto bikeCategoryDto)
    {
        var response = new Response<BikeCategoryDto>();
        
        if (!await _bikeCategoryService.BikeCategoryExist(bikeCategoryDto.id))
        {
            response.Errors.Add("Bike Category not Found");
            return NotFound(response);
        }

        if (await _bikeCategoryService.ExistByName(bikeCategoryDto.Bike_type, bikeCategoryDto.id))
        {
            response.Errors.Add($"Bike Category name {bikeCategoryDto.Bike_type} already exist");
            return BadRequest(response);
        }
        
        response.Data = await _bikeCategoryService.UpdateAsync(bikeCategoryDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _bikeCategoryService.BikeCategoryExist(id))
        {
            response.Errors.Add("Bike category not found");
            return NotFound(response);
        }

        var deleted = await _bikeCategoryService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete bike category");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

