using NetBank.Domain.Interfaces;
using System.Text.RegularExpressions;
namespace NetBank.Domain
{
    public class InstaPayment : ICreditCardValidator
    {
        public const int MIN_LENGTH = 16;
        public const int MAX_LENGTH = 16;
        public const string REGEX_BRAND_STRING = "^(637|638|639)";
        public const string BRAND = "InstaPayment";
        public bool CheckLength(CreditCard creditCard)
        {
            return (MIN_LENGTH == creditCard.CreditCardNumber.Length || MAX_LENGTH == creditCard.CreditCardNumber.Length);
        }

        public bool IsValidIssuingNetwork(CreditCard creditCard)
        {
            return (Regex.IsMatch(creditCard.CreditCardNumber, REGEX_BRAND_STRING));
        }

        public string GetBrand()
        {
            return BRAND;
        }
    }
}
