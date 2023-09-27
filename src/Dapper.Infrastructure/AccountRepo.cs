using System.Data;
using Dapper.Domain;
using Dapper.Domain.Repositories;

namespace Dapper.Infrastructure;


public class AccountRepo : IAccountRepo
{
    private readonly IDbTransaction _transaction;

    private IDbConnection Connection => _transaction.Connection;

    public AccountRepo(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task<Account> AddAsync(Account account)
    {
        account = await Connection.ExecuteScalarAsync<Account>(
            @"INSERT INTO accounts(owner, balance, currency) VALUES (@Owner, @Balance, @Currency) RETURN *;",
            new
            {
                account.Owner,
                account.Balance,
                account.Currency
            },
            _transaction);
        return account;
    }

    public async Task<IEnumerable<Account>> QueryAsync(long page, long size)
    {
        return await Connection.QueryAsync<Account>(
            @"Select * from accounts where id = @page order by id limit @size",
            new
            {
                page,
                size
            },
            _transaction);
    }
}

