using Microsoft.EntityFrameworkCore;

namespace TimeZebra.Invoices.ReadModel.EntityFramework.DBContext
{
    public class RestInvoiceReadModelContext : DbContext
    {
        public RestInvoiceReadModelContext(DbContextOptions<RestInvoiceReadModelContext> options) : base(options)
        {
        }
        
        public DbSet<InvoiceReadModel> Invoices { get; set; }
    }
}