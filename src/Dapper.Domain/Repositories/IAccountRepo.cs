using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Domain.Repositories;


public interface IAccountRepo
{
    Task<Account> AddAsync(Account account);

    Task<IEnumerable<Account>> QueryAsync(long page, long size);
}

