using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentDomain.Entities
{
    public class Payment
    {
        [Key]
        public int id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? SecurityCode { get; set; }
        public decimal Amount { get; set; }

    }
}
