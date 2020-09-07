using EventFlow.Core;

namespace TimeZebra.Invoicing.Domain
{
    public class InvoiceId : Identity<InvoiceId>
    {
        public InvoiceId(string value) : base(value)
        {
        }
    }
}