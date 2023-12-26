namespace NetBank.Domain
{
    public class CreditCard
    {
        public string CreditCardNumber { get; set; }
        public string IssuingNetwork { get; set; }
        public bool IsValid { get; set; }

        public CreditCard(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
            IsValid = false;
            IssuingNetwork = string.Empty;
        }
    }
}
