using ABugsDeath.Services.ServiceBuilders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Interfaces
{
    public interface IServiceFactory
    {
        IServiceBuilder Builder { get; }

        IService BuildService(string BuilderName);
    }
}
