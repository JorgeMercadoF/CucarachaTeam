using ABugsDeath.Interfaces;

namespace ABugsDeath.Services.ServiceStrategies
{
    public class ServiceContext : IServiceStrategy
    {
        public IServiceStrategy CurrentStrategy { get; set; }

        #region Public Methods: IServiceStrategy
        public void GoToPlace()
        {
            this.CurrentStrategy.GoToPlace();
        }

        public void Kill()
        {
            this.CurrentStrategy.Kill();
        }

        public void CleanPlace()
        {
            this.CurrentStrategy.CleanPlace();
        }
        #endregion
    }
}
