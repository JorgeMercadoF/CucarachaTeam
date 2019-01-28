using ABugsDeath.Animals;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Services.ServiceBuilders.FleaServiceBuilders
{
    public class FleaPremiumServiceBuilder : IServiceBuilder
    {
        #region Private Attributes
        private ServiceBase ServiceBase;
        FactoriaRecursos factoria = new FactoriaRecursos();
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
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("SimpleMask", 80, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("Bleach", 0.5m, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVehiculo("Renault", "Kangoo", 5, 12197, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVeneno("Arsenico", 1.5m, 3));
        }
        #endregion
    }
}
