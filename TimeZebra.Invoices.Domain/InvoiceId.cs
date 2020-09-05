using EventFlow.Core;

namespace TimeZebra.Invoices.Domain
{
    public class InvoiceId : Identity<InvoiceId>
    {
        public InvoiceId(string value) : base(value)
        {
        }
    }
}