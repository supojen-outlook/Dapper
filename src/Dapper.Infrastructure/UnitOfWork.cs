using System.Data;
using Dapper.Domain.Repositories;
using Npgsql;

namespace Dapper.Infrastructure;


public class UnitOfWork
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;
    private IAccountRepo? _accountRepo;

    public UnitOfWork(string conStr)
    {
        // connect to database
        _connection = new NpgsqlConnection(conStr);
        _connection.Open();
    }


    public void Begin(IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        _transaction = _connection.BeginTransaction(level);
    }

    public void Commit()
    {
        if (_transaction == null) 
            throw new ArgumentNullException($"You must start a transaction first");

        try
        {
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            ResetRepositories();
        }
    }

    
    public IAccountRepo AccountRepo
    {
        get
        {
            if (_transaction == null)
                throw new ArgumentNullException($"You must start a transaction first");

            if (_accountRepo == null)
                _accountRepo = new AccountRepo(_transaction);

            return _accountRepo;
        }
    }


    private void ResetRepositories()
    {
        _accountRepo = null;
    }
}

