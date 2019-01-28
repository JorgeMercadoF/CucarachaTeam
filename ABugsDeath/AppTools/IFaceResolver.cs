using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ABugsDeath.AppTools
{
    /// <summary>
    /// Clase singleton para obtener referencias a diferentes interfaces (IService e IServiceBuilder por ahora) y las clases que las implementan
    /// </summary>
    public class IFaceResolver
    {
        public Dictionary<string, Type> ServiceFactoryAvailableTypes { get; private set; }
        public Dictionary<string, Type> ServiceBuiderAvailableTypes { get; private set; }
        public Dictionary<string, Type> ServiceAvailableTypes { get; private set; }

        private static IFaceResolver _Instance = null;

        private IFaceResolver()
        {
            var AllTypes = Assembly.GetExecutingAssembly().GetTypes();

            this.ServiceFactoryAvailableTypes = AllTypes.Where(x => x.GetInterface(typeof(IServiceFactory).ToString()) != null).ToDictionary(x => x.Name, x => x);
            this.ServiceBuiderAvailableTypes = AllTypes.Where(x => x.GetInterface(typeof(IServiceBuilder).ToString()) != null).ToDictionary(x => x.Name, x => x);
            this.ServiceAvailableTypes = AllTypes.Where(x => x.GetInterface(typeof(IService).ToString()) != null).ToDictionary(x => x.Name, x => x);
        }

        public static IFaceResolver GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new IFaceResolver();
            }

            return _Instance;
        }
    }
}
