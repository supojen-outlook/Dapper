using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Shouldly;
using Xunit;

namespace Dapper.Infrastructure.Test
{
    public class UnitOfWorkTest
    {
        /// <summary>
        /// Postgres Connection String
        /// </summary>
        protected string ConnectionString
        {
            get
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("Postgres");
                if (connectionString == null)
                    throw new ArgumentNullException($"Cannot read the connection string.");
                return connectionString;
            }
        }

    }
}
