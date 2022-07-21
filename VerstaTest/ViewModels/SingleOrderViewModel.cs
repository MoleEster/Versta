using System;

namespace VerstaTest.ViewModels
{
    public class SingleOrderViewModel
    {
        public Guid Id { get; set; }
        public string AdressersCity { get; set; }

        public string AdressersAdress { get; set; }

        public string RecipientsCity { get; set; }

        public string RecipientsAdress { get; set; }

        public double CargoWeight { get; set; }

        public DateTime CollectionDate { get; set; }
    }
}
