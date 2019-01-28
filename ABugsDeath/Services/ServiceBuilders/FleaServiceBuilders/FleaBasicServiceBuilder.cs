using ABugsDeath.Animals;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using System.Collections.Generic;

namespace ABugsDeath.Services.ServiceBuilders.FleaServiceBuilders
{
    public class FleaBasicServiceBuilder : IServiceBuilder
    {
        #region Private Attributes
        private ServiceBase ServiceBase;
        private FactoriaRecursos factoria = new FactoriaRecursos();
        #endregion

        #region Public Properties
        public IService Service { get { return this.ServiceBase; } }
        #endregion

        #region Public Methods: IServiceBuilder
        public void CreateService()
        {
            this.ServiceBase = new FleaService() { Animal = new Flea() };
        }

        public void SetAssets()
        {
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("ProtectionSuite", 1000, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("Helmet", 80, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearVehiculo("Renault", "Kangoo", 5, 12197, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVeneno("Arsenico", 0.3m, 1));
        }
        #endregion
    }
}
