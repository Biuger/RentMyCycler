using Microsoft.AspNetCore.Mvc;
using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;
using RentMyCycler.Core.http;

namespace RentMyCycler.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    
    public PaymentsController(IPaymentRepository paymentRepository, IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Payments>>>> GetAll()
    {
        var response = new Response<List<PaymentDto>>
        {
            Data = await _paymentService.GetAllAsync()
        };
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Payments>>> Post([FromBody] PaymentDto paymentDto)
    {
        var response = new Response<PaymentDto>
        {
            Data = await _paymentService.SaveAsync(paymentDto)
        };

        
       
        return Created($"/api/[controller]/{paymentDto.id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<PaymentDto>>> GetById(int id)
    {
        var response = new Response<PaymentDto>();
        
        
        if (!await _paymentService.PaymentExist(id))
        {
            response.Errors.Add("Payment Not Found");
            return NotFound(response);
        }

        response.Data = await _paymentService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Response<PaymentDto>>> Update(int id, [FromBody] PaymentDto paymentDto)
    {
        var response = new Response<PaymentDto>();
        if (!await _paymentService.PaymentExist(id))
        {
            response.Errors.Add("Payment not found");
            return NotFound(response);
        }

        paymentDto.id = id; // Actualizamos el ID con el valor recibido en la ruta
        response.Data = await _paymentService.UpdateAsync(paymentDto);
        return Ok(response);
    }

    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
    
        if (!await _paymentService.PaymentExist(id))
        {
            response.Errors.Add("Payment not found");
            return NotFound(response);
        }

        var deleted = await _paymentService.DeleteAsync(id);
        if (!deleted)
        {
            response.Errors.Add("Failed to delete Payment");
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        response.Data = true;
        return Ok(response);
    }

    
}

