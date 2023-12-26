using NetBank.Domain.Interfaces;
using System.Text.RegularExpressions;
namespace NetBank.Domain
{
    public class JCB : ICreditCardValidator
    {
        public const int MIN_LENGTH = 16;
        public const int MAX_LENGTH = 19;
        public const string REGEX_BRAND_STRING = "^(352[89]|35[3-8][0-9])";
        public const string BRAND = "JCB";
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
