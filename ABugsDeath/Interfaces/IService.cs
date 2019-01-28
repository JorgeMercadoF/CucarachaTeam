
using ABugsDeath.Assets;
using ABugsDeath.Services.ServiceStrategies;
using System.Collections.Generic;


namespace ABugsDeath.Interfaces
{
    public interface IService : ICost
    {
        WorkerBase Team { get; set; }
        IPoison Poison { get; set; }
        IAnimal Animal { get; set; }
        List<IRecurso> Assets { get; set; }

        void PerformService();

        #region Strategy Methods
        void SlowStrategy();
        void MediumStrategy();
        void FullSpeedStrategy();
        void JSONInvoiceStrategy();
        void PlainTextInvoiceStrategy();
        #endregion
    }
}
