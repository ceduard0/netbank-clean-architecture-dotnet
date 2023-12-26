using NetBank.Domain.Interfaces;
using System.Text.RegularExpressions;
namespace NetBank.Domain
{
    public class Discover : ICreditCardValidator
    {
        public const int MIN_LENGTH = 16;
        public const int MAX_LENGTH = 19;
        public const string REGEX_BRAND_STRING = "^(6011|644|645|646|647|648|649|65|(62212[6-9]|6221[3-9][0-9]|622[2-8][0-9]{2}|6229[01][0-9]|62292[0-5]))";
        public const string BRAND = "Discover";
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
