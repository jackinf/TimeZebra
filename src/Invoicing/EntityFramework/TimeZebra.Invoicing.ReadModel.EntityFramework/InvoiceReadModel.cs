using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using TimeZebra.Invoicing.Domain;
using TimeZebra.Invoicing.Domain.Invoices.Events;

namespace TimeZebra.Invoicing.ReadModel.EntityFramework
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