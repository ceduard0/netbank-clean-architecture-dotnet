using NetBank.Domain.Interfaces;
using System.Text.RegularExpressions;
namespace NetBank.Domain
{
    public class VisaElectron : ICreditCardValidator
    {
        public const int MIN_LENGTH = 16;
        public const int MAX_LENGTH = 16;
        public const string REGEX_BRAND_STRING = "^(4026|417500|4508|4844|4913|4917)";
        public const string BRAND = "Visa Electron";
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
