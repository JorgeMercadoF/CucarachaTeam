using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Invoices.InvoiceSerializeStrategies
{
    public class InvoiceSerializeContext : IInvoiceStrategy
    {
        public IInvoiceStrategy CurrentStrategy { get; set; }

        public Invoice Invoice { get; set; }

        #region Public Methods: IInvoiceStrategy
        public string SerializeInvoice()
        {
            return this.CurrentStrategy.SerializeInvoice();
        }
        #endregion
    }
}
