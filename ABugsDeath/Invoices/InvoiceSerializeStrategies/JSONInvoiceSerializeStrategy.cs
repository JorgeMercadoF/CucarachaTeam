using ABugsDeath.Interfaces;
using ABugsDeath.Services;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ABugsDeath.Invoices.InvoiceSerializeStrategies
{
    public class JSONInvoiceSerializeStrategy : IInvoiceStrategy
    {
        public Invoice Invoice { get; set; }

        public JSONInvoiceSerializeStrategy(Invoice Invoice)
        {
            this.Invoice = Invoice;
        }

        public string SerializeInvoice()
        {
            var Serializer = new JsonSerializer();
            var ResultFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{this.Invoice.Service}_{DateTime.Now}.json";

            using (var Writer = new StreamWriter(ResultFilePath))
            {
                using (var JSONWriter = new JsonTextWriter(Writer))
                {
                    Serializer.Serialize(JSONWriter, this.Invoice);
                }
            }

            if (File.Exists(ResultFilePath))
            {
                return ResultFilePath;
            }
            else
            {
                return null;
            }
        }
    }
}
