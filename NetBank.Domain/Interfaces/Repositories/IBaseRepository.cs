using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBank.Domain.Interfaces;

namespace NetBank.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>: ICreditCard<TEntity>, ITransaction
    {
    }
}
