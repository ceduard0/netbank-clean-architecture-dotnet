using NetBank.Domain.Interfaces;
using System.Text.RegularExpressions;
namespace NetBank.Domain
{
    public class Maestro : ICreditCardValidator
    {
        public const int MIN_LENGTH = 16;
        public const int MAX_LENGTH = 19;
        public const string REGEX_BRAND_STRING = "^(5018|5020|5038|5893|6304|6759|6761|6762|6763)";
        public const string BRAND = "Maestro";
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
