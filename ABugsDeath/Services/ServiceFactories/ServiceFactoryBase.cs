using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Services.ServiceFactories
{
    public abstract class ServiceFactoryBase : IServiceFactory
    {
        #region Public Properties
        public IServiceBuilder Builder { get; private set; }
        #endregion

        public abstract IService BuildService(string BuilderName);
    }
}
