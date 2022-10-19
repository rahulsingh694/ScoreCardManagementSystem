// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.Data.Sqlite;

// namespace ScoreCardManagement.Test
// {
   
//     public class InMemoryDbContext : IDisposable
//     {
//          private const string InMemoryConnectionString = "DataSource=:memory:";
//          private readonly SqliteConnection _connection;
//          protected readonly Context DbContext;
//          _connection = new SqliteConnection(InMemoryConnectionString);
//             _connection.Open();
//             var options = new DbContextOptionsBuilder<TensechDatabaseContext>()
//                    .UseSqlite(_connection)
//                    .Options;
//             DbContext = new TensechDatabaseContext(options);
//             DbContext.Database.EnsureCreated();

//         public void Dispose()
//         {
//             _connection.Close();
//         }

//     }
    
// }