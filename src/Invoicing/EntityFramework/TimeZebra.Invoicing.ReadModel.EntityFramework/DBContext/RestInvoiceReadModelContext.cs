using Microsoft.EntityFrameworkCore;

namespace TimeZebra.Invoicing.ReadModel.EntityFramework.DBContext
{
    public class RestInvoiceReadModelContext : DbContext
    {
        public RestInvoiceReadModelContext(DbContextOptions<RestInvoiceReadModelContext> options) : base(options)
        {
        }
        
        public DbSet<InvoiceReadModel> Invoices { get; set; }
    }
}