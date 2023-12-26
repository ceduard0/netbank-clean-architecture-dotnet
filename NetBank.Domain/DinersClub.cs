using NetBank.Domain.Interfaces;
using System.Text.RegularExpressions;
namespace NetBank.Domain
{
    public class DinersClub : ICreditCardValidator
    {
        public const int MIN_LENGTH = 14;
        public const int MAX_LENGTH = 16;
        public const string REGEX_BRAND_CARTE_BLANCHE = "^(300|301|302|303|304|305)";
        public const string REGEX_BRAND_INTERNATIONAL = "^(36)";
        private string brand = "Diners Club";
        public bool CheckLength(CreditCard creditCard)
        {
            return (MIN_LENGTH == creditCard.CreditCardNumber.Length || MAX_LENGTH == creditCard.CreditCardNumber.Length);
        }

        public bool IsValidIssuingNetwork(CreditCard creditCard)
        {
            if (Regex.IsMatch(creditCard.CreditCardNumber, REGEX_BRAND_CARTE_BLANCHE))
            {
                brand += " - Carte Blanche";
                return true;
            }

            if (Regex.IsMatch(creditCard.CreditCardNumber, REGEX_BRAND_INTERNATIONAL))
            {
                brand += " - International";
                return true;
            }

            return false;
        }

        public string GetBrand()
        {
            return brand;
        }
    }
}
