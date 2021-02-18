using Microsoft.EntityFrameworkCore;
using PaymentDomain.Data;
using PaymentDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentDomain.Services
{
    public interface IPaymentRepository
    {
        Task IExpensivePaymentGateway(Payment model);
        Task ICheapPaymentGateway(Payment model);
        Task<List<Payment>> getPayment();
        Task PremiumPaymentService(Payment model);
        Task UpdatePayment(Payment model);
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;
        public PaymentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> getPayment()
        {
            var result = await _context.Payments.ToListAsync();

            return result;
        }

        public async Task IExpensivePaymentGateway(Payment model)
        {
            var result = _context.Payments.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task ICheapPaymentGateway(Payment model)
        {
            var result = _context.Payments.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task PremiumPaymentService(Payment model)
        {
            var result = _context.Payments.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePayment(Payment model)
        {
            var payment = await _context.Payments.Where(q => q.id == model.id ).FirstOrDefaultAsync();

            payment.CreditCardNumber = model.CreditCardNumber;
            payment.CardHolder = model.CardHolder;
            payment.ExpirationDate = model.ExpirationDate;
            payment.SecurityCode = model.SecurityCode;
            payment.Amount = model.Amount;

            _context.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}

