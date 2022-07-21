using System;
using System.ComponentModel.DataAnnotations;

namespace VerstaTest.Data.Data
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        public string AdressersCity { get; set; }

        [Required]
        public string AdressersAdress { get; set; }

        [Required]
        public string RecipientsCity { get; set; }

        [Required]
        public string RecipientsAdress { get; set; }

        [Required]
        public double CargoWeight { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }

    }
}
