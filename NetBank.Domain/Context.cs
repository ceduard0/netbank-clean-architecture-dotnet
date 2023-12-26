using NetBank.Domain.Interfaces;

namespace NetBank.Domain
{
    public class Context
    {
        private ICreditCardValidator _creditCardValidator;

        public Context() { }
        public Context(ICreditCardValidator creditCardValidator)
        {
            _creditCardValidator = creditCardValidator;
        }

        public void SetValidator(ICreditCardValidator creditCardValidator)
        {
            _creditCardValidator = creditCardValidator;
        }

        public bool CheckLength(CreditCard creditCard)
        {
            return _creditCardValidator.CheckLength(creditCard);
        }

        public bool IsValidIssuingNetwork(CreditCard creditCard)
        {
            return _creditCardValidator.IsValidIssuingNetwork(creditCard);
        }

        public string GetBrand()
        {
            return _creditCardValidator.GetBrand();
        }

    }


}
