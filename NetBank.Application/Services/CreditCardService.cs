using NetBank.Application.Interfaces;
using NetBank.Domain;
using NetBank.Domain.Interfaces.Repositories;
using System.Net;
using System.Text.RegularExpressions;

namespace NetBank.Application.Services
{
    public class CreditCardService : IBaseService<CreditCard>
    {

        private const string DEFAULT_NOT_FOUND_MESSAGE = "Not Found";
        private const string DEFAULT_BAD_REQUEST_MESSAGE = "Bad Request";
        private const string REGEX_NUMBERS = "^[0-9]*$";

        private readonly IBaseRepository<CreditCard> creditCardRepository;
        private List<Context> brands = new List<Context>();


        public CreditCardService(IBaseRepository<CreditCard> _creditCardRepository)
        {
            creditCardRepository = _creditCardRepository;
            GetBrands();
        }
        public CreditCard Validate(CreditCard entity)
        {
            if (!InputCheck(entity))
            {
                entity = GetIssuingNetwork(entity);
                entity.IsValid = CheckCreditCardNumber(entity.CreditCardNumber);
            }

            return entity;
        }

        public CreditCard GetIssuingNetwork(CreditCard creditCard)
        {
            foreach (Context brand in brands)
            {
                if (brand.CheckLength(creditCard) && brand.IsValidIssuingNetwork(creditCard))
                {
                    creditCard.IssuingNetwork = brand.GetBrand();
                    return creditCard;
                }
            }

            throw new KeyNotFoundException(DEFAULT_NOT_FOUND_MESSAGE);

        }


        private bool InputCheck(CreditCard creditCard)
        {
            return (creditCard == null || !Regex.IsMatch(creditCard.CreditCardNumber, REGEX_NUMBERS)) ? throw new FormatException(DEFAULT_BAD_REQUEST_MESSAGE) : false ;
        }
        private void GetBrands()
        {
            brands.Add(new Context(new Visa()));
            brands.Add(new Context(new AmericanExpress()));
            brands.Add(new Context(new DinersClub()));
            brands.Add(new Context(new InstaPayment()));
            brands.Add(new Context(new Discover()));
            brands.Add(new Context(new JCB()));
            brands.Add(new Context(new Maestro()));
            brands.Add(new Context(new MasterCard()));
            brands.Add(new Context(new VisaElectron()));
        }

        private bool CheckCreditCardNumber(string creditCardNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                char[] value = creditCardNumber.ToArray();
                int number = int.Parse(value[i].ToString());

                if (alternate)
                {
                    number *= 2;

                    if (number > 9)
                    {
                        number = (number % 10) + 1;
                    }
                }
                sum += number;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

    }
}
