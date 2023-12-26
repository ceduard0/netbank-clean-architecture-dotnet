using NetBank.Domain.Interfaces;

namespace NetBank.Application.Interfaces
{
    public interface IBaseService<TEntity> : ICreditCard<TEntity>
    {
    }
}
