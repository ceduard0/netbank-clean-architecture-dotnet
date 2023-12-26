using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBank.Domain;
using NetBank.Domain.Interfaces;
using NetBank.Domain.Interfaces.Repositories;

namespace NetBank.Infrastructure.Data.Repositories
{
    public class CreditCardRepository : IBaseRepository<CreditCard>
    {
        public void SaveAll()
        {
            Console.WriteLine("CreditCardRepository ... ");
        }

        public CreditCard Validate(CreditCard entity)
        {
            return entity;
        }
    }
}
