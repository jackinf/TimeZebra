using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventFlow.ReadStores;

namespace TimeZebra.Invoices.ReadModel.EntityFramework
{
    public class InvoiceReadModel : IReadModel
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; protected set; }

        [ConcurrencyCheck] public long Version { get; set; }

        public string TTitle { get; set; }
    }
}