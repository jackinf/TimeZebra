using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using TimeZebra.Invoices.Domain;
using TimeZebra.Invoices.Domain.Invoices.Events;

namespace TimeZebra.Invoices.ReadModel.EntityFramework
{
    public class InvoiceReadModel : IReadModel,
        IAmReadModelFor<InvoiceAggregate, InvoiceId, InvoiceCreatedEvent> 
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; protected set; }

        [ConcurrencyCheck] public long Version { get; set; }

        public string Title { get; set; }
        
        public void Apply(IReadModelContext context, IDomainEvent<InvoiceAggregate, InvoiceId, InvoiceCreatedEvent> domainEvent)
        {
            Title = domainEvent.AggregateEvent.Title;
        }
    }
}