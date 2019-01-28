using ABugsDeath.Animals;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;

namespace ABugsDeath.Services.ServiceBuilders.RatServiceBuilders
{
    public class RatBasicServiceBuilder : IServiceBuilder
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
            this.ServiceBase = new RatService() { Animal = new Rat() };
        }

        public void SetAssets()
        {
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("ProtectionSuite", 1000, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("SimpleMask", 80, 3));
            this.ServiceBase.Assets.AddRange(factoria.CrearMaterial("Bleach", 0.5m, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVehiculo("Mercedes", "Sprinter", 5, 28721, 1));
            this.ServiceBase.Assets.AddRange(factoria.CrearVeneno("Cianuro", 0.5m, 3));
        }
        #endregion
    }
}
