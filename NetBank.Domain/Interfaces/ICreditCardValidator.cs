namespace NetBank.Domain.Interfaces
{
    public interface ICreditCardValidator
    {

        bool CheckLength(CreditCard creditCard);

        bool IsValidIssuingNetwork(CreditCard creditCard);

        string GetBrand();
    }
}
