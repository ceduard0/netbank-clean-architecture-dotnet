namespace NetBank.Domain.Interfaces
{
    public interface ICreditCard<TEntity>
    {
        TEntity Validate(TEntity entity);
    }
}
