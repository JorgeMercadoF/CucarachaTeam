using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Interfaces
{
    public interface IServiceBuilder
    {
        IService Service { get; }

        void CreateService();
        void SetAssets();
    }
}
