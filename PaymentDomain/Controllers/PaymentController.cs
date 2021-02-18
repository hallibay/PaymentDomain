using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentDomain.Entities;
using PaymentDomain.Services;

namespace PaymentDomain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _PaymentRepository;

        public PaymentController(IPaymentRepository repository)
        {
            _PaymentRepository = repository;
        }

        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment(Payment model)
        {
            try
            {
                if (model.Amount < 20)
                {
                    await _PaymentRepository.ICheapPaymentGateway(model);

                    var status = true;
                    return Ok(status);
                }
                else if (model.Amount  >= 21 && model.Amount <= 500)
                {
                    await _PaymentRepository.IExpensivePaymentGateway(model);

                    var status = true;
                    return Ok(status);
                }
                else
                {
                    await _PaymentRepository.PremiumPaymentService(model);

                    var status = true;
                    return Ok(status);
                }
            }
            catch (Exception ex)
            {
                var status = false;
                return BadRequest(status);
            }

        }
        [HttpGet("GetPayment")]
        public async Task<IActionResult> GetPayment()
        {
            try
            {
                var getVitals = await _PaymentRepository.getPayment();
                //var status = true;
                return Ok(getVitals);
            }
            catch (Exception ex)
            {
                var status = false;
                return BadRequest(status);
            }

        }

        [HttpPost("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment(Payment model)
        {

            try
            {
                await _PaymentRepository.UpdatePayment(model);

                var status = true;
                return Ok(status);
            }
            catch (Exception ex)
            {
                var status = false;
                return BadRequest(status);
            }
        }
    }

}
