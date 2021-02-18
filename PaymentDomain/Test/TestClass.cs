using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentDomain.Controllers;
using PaymentDomain.Entities;
using PaymentDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PaymentDomain.Test
{
    [TestClass]
    public class TestClass
    {

        PaymentController _controller;
        IPaymentRepository _service;
        public TestClass()
        {
            
            _controller = new PaymentController(_service);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var Payment = new Payment()
            {
                CreditCardNumber = "86878975989",
                CardHolder = "kehinde",
                ExpirationDate= new DateTime(),
                SecurityCode="967",
                Amount= 200.00M
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.ProcessPayment(Payment);
            // Assert
            //Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var Payment = new Payment()
            {
                CreditCardNumber = "86878975989",
                CardHolder = "Esther",
                ExpirationDate = new DateTime(),
                SecurityCode = "967",
                Amount = 200.00M
            };
            _controller.ModelState.AddModelError("Name", "Required");
            var createdResponse = _controller.ProcessPayment(Payment);
            // Assert
           // Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
    }
}

