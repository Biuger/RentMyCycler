using RentMyCycler.Api.DTO;
using RentMyCycler.Api.Repositories.Interfaces;
using RentMyCycler.Api.Services.Interfaces;
using RentMyCycler.Core.Entities;

namespace RentMyCycler.Api.Services;

public class PaymentService: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    
    public async Task<bool> PaymentExist(int id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);

        return (payment != null);
    }

    public async Task<PaymentDto> SaveAsync(PaymentDto paymentDto)
    {
        var payment = new Payments
        {
            Id_reserve = paymentDto.Id_reserve, 
            Payment_method = paymentDto.Payment_method,
            Amount = paymentDto.Amount,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        payment = await _paymentRepository.SaveAsync(payment);
        paymentDto.id = payment.id;
        return paymentDto;
    }

    public async Task<PaymentDto> UpdateAsync(PaymentDto paymentDto)
    {
        var payment = await _paymentRepository.GetByIdAsync(paymentDto.id);
        

        if (payment == null)
        {
            throw new Exception("Payment not found");
        }

        payment.Id_reserve = paymentDto.Id_reserve;
        payment.Payment_method = paymentDto.Payment_method;
        payment.Amount = paymentDto.Amount;
        payment.UpdatedBy = "";
        payment.UpdatedDate = DateTime.Now;
        await _paymentRepository.UpdateAsync(payment);
        return paymentDto;
    }

    public async Task<List<PaymentDto>> GetAllAsync()
    {
        var payments = await _paymentRepository.GetAllAsync();
        var paymentsDto = payments.Select(c => new PaymentDto(c)).ToList();

        return paymentsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _paymentRepository.DeleteAsync(id);
    }

    public async Task<PaymentDto> GetByIdAsync(int id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);
        if (payment == null)
            throw new Exception("Payment not found");
        var paymentDto = new PaymentDto(payment);
        return paymentDto;
    }
}