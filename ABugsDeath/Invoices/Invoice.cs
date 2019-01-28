using ABugsDeath.Interfaces;
using ABugsDeath.Invoices.InvoiceSerializeStrategies;
using System.Collections.Generic;

namespace ABugsDeath.Invoices
{
    public class Invoice
    {
        #region Public "Inner" class
        public class Concept : ICost
        {
            public string ConceptDesc { get; set; }
            public int Units { get; set; }
            public decimal UnitPrice { get; set; }

            public decimal Price => this.UnitPrice * Units;
        }
        #endregion

        #region Private Properties
        private InvoiceSerializeContext Context { get; set; }
        #endregion

        #region Public Properties
        public string Client { get; set; }

        public string Service { get; set; }

        public string ServicePlan { get; set; }

        public List<Concept> Concepts { get; set; }

        public decimal Total { get; set; }
        #endregion

        #region Constructor
        public Invoice()
        {
            this.Context = new InvoiceSerializeContext();
        }
        #endregion

        #region Public Methods: IInvoiceStrategy Strategy Methods
        public void JSONStrategy()
        {
            this.Context.CurrentStrategy = new JSONInvoiceSerializeStrategy(this);
        }

        public void PlainTextStrategy()
        {
            //this.Context.CurrentStrategy = new PlainTextSerializeStrategy(this);
        }
        #endregion

        #region Private Methods
        public void SerializeInvoice()
        {
            this.Context.SerializeInvoice();
        }
        #endregion
    }
}
