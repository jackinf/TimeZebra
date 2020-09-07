using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TimeZebra.Invoicing.ReadModel.EntityFramework.DBContext
{
    public class RestInvoiceReadModelDbContextProvider : IDbContextProvider<RestInvoiceReadModelContext>
    {
        private readonly DbContextOptions<RestInvoiceReadModelContext> _options;

        public RestInvoiceReadModelDbContextProvider(IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ReadModelConnectionString"];
            _options = new DbContextOptionsBuilder<RestInvoiceReadModelContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public RestInvoiceReadModelContext CreateContext()
        {
            var context = new RestInvoiceReadModelContext(_options);
            context.Database.Migrate();
            return context;
        }
    }
}