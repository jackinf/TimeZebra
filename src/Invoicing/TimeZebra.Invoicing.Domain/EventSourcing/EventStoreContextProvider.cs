using System;
using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TimeZebra.Invoicing.Domain.EventSourcing
{
    public class EventStoreContextProvider: IDbContextProvider<EventStoreContext>, IDisposable
    {
        private readonly DbContextOptions<EventStoreContext> _options;

        public EventStoreContextProvider(IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:EventStoreConnectionString"];
            _options = new DbContextOptionsBuilder<EventStoreContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        
        public EventStoreContext CreateContext()
        {
            var db = new EventStoreContext(_options);
            db.Database.EnsureCreated();

            return db;
        }

        public void Dispose()
        {
        }
    }
}