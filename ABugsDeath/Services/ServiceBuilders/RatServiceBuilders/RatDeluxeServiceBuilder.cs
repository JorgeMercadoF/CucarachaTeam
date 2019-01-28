using ABugsDeath.Animals;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;

namespace ABugsDeath.Services.ServiceBuilders.RatServiceBuilders
{
    public class RatDeluxeServiceBuilder : IServiceBuilder
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
            this.ServiceBase = new RatService() { Animal = new Rat() };
        }

        public void SetAssets()
        {
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("ProtectionSuite", 1000, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("SimpleMask", 80, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("Bleach", 0.5m, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVehiculo("Renault", "Kangoo", 5, 12197, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVeneno("Arsenico", 0.3m, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVeneno("Cianuro", 0.4m, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVeneno("Estricnina", 0.5m, 1));
        }
        #endregion
    }
}
