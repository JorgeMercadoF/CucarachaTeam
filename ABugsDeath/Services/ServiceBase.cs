using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using ABugsDeath.Invoices;
using ABugsDeath.Invoices.InvoiceSerializeStrategies;
using ABugsDeath.Services.ServiceStrategies;
using System.Collections.Generic;

namespace ABugsDeath.Services
{
    public abstract class ServiceBase : IService
    {
        #region Private Properties
        private ServiceContext ServiceContext { get; set; }

        private InvoiceSerializeContext SerializeContext { get; set; }
        #endregion

        #region Public Properties
        public string Name { get; set; }
        public string Plan { get; set; }
        public WorkerBase Team { get; set; }
        public IPoison Poison { get; set; }
        public IAnimal Animal { get; set; }
        public List<IRecurso> Assets { get; set; }
        public decimal Price
        {
            get
            {
                var Total = this.Team.Price;

                foreach (var Asset in this.Assets)
                {
                    Total += Asset.GetPrecioRecurso();
                }

                return Total;
            }
        }
        #endregion

        #region Constructor
        public ServiceBase()
        {
            this.Assets = new List<IRecurso>();
            this.ServiceContext = new ServiceContext();
            this.SerializeContext = new InvoiceSerializeContext();
        }
        #endregion

        #region Public Methods: IService
        public void PerformService()
        {
            this.GoToPlace();
            this.Kill();
            this.CleanPlace();
            this.GenerateInvoice();
        }
        #endregion

        #region Public Methods: IService Strategy Methods
        public void SlowStrategy()
        {
            this.ServiceContext.CurrentStrategy = new SlowStrategy(this);
        }

        public void MediumStrategy()
        {
            this.ServiceContext.CurrentStrategy = new MediumStrategy(this);
        }

        public void FullSpeedStrategy()
        {
            this.ServiceContext.CurrentStrategy = new FullSpeedStrategy(this);
        }

        public void JSONInvoiceStrategy()
        {
            this.SerializeContext.CurrentStrategy = new JSONInvoiceSerializeStrategy(new Invoices.Invoice());
        }

        public void PlainTextInvoiceStrategy()
        {
            //this.SerializeContext.CurrentStrategy = new JSONInvoiceSerializeStrategy(this);
        }
        #endregion

        #region Private Methods
        public void GoToPlace()
        {
            this.ServiceContext.GoToPlace();
        }

        public void Kill()
        {
            this.ServiceContext.Kill();
        }

        public void CleanPlace()
        {
            this.ServiceContext.CleanPlace();
        }

        public string GenerateInvoice()
        {
            var Concepts = new List<Invoice.Concept>()
            {
                new Invoice.Concept() { ConceptDesc = $"Mano de obra", UnitPrice = this.Team.Price, Units = 1 },
                new Invoice.Concept() { ConceptDesc = $"Veneno utilizado", UnitPrice = this.Poison.Price, Units = 1 }
            };

            foreach (var Asset in Assets)
            {
                Concepts.Add(new Invoice.Concept() { ConceptDesc = "Asset", Units = 1, UnitPrice = Asset.GetPrecioRecurso()});
            }

            var NewInvoice = new Invoice()
            {
                Client = "asdf",
                Service = this.Name,
                ServicePlan = this.Plan,
                Concepts = Concepts,
                Total = this.Price
            };

            this.SerializeContext.CurrentStrategy.Invoice = NewInvoice;

            return this.SerializeContext.SerializeInvoice();
        }
        #endregion
    }
}
