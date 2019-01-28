using ABugsDeath.Invoices;

namespace ABugsDeath.Interfaces
{
    public interface IInvoiceStrategy
    {
        Invoice Invoice { get; set; }

        string SerializeInvoice();
    }
}
