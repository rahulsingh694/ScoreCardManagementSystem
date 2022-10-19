using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardManagement.Tests
{
    public class InMemoryDbContext :IDisposable
    {
         private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly PlayerContext DbContext;

        protected InMemoryDbContext()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<PlayerContext>()
                   .UseSqlite(_connection)
                   .Options;
            DbContext = new PlayerContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}