using ABugsDeath.AppTools;
using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ABugsDeath.Services
{
    /// <summary>
    /// Clase general de factorías de servicios.
    /// </summary>
    public class ServiceMainFactory
    {
        #region Private Attributes
        private Dictionary<string, Type> AvailableTypes;
        #endregion

        #region Constructor
        /// <summary>
        /// Clase general de factorías de servicios.
        /// </summary>
        public ServiceMainFactory()
        {
            this.AvailableTypes = IFaceResolver.GetInstance().ServiceFactoryAvailableTypes;
        }
        #endregion

        #region Public Methods
        public IServiceFactory GetServiceFactory(string ServiceType)
        {
            if (this.AvailableTypes.ContainsKey(ServiceType))
            {
                return (IServiceFactory)Activator.CreateInstance(this.AvailableTypes[ServiceType]);
            }
            else
            {
                throw new ArgumentException("Service unavailable or still not implemented.");
            }
        }
        #endregion

        #region Private Methods: Helpers
        private bool BuilderFilter(KeyValuePair<string, Type> Tuple)
        {
            var KeyMin = Tuple.Key.ToLower();

            return KeyMin.StartsWith("flea") && KeyMin.EndsWith("servicebuilder");
        }
        #endregion
    }
}
