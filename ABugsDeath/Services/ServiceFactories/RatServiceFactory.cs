﻿using ABugsDeath.AppTools;
using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABugsDeath.Services.ServiceFactories
{
    public class RatServiceFactory : IServiceFactory
    {
        #region Private Attributes
        private Dictionary<string, Type> AvailableBuilders;
        #endregion

        #region Public Properties
        public IServiceBuilder Builder { get; private set; }
        #endregion

        #region Constructor
        public RatServiceFactory()
        {
            this.AvailableBuilders = IFaceResolver.GetInstance().ServiceBuiderAvailableTypes.Where(BuilderFilter).ToDictionary(x => x.Key, x => x.Value);
        }
        #endregion

        public IService BuildService(string BuilderName)
        {
            var builderlower = BuilderName.ToLower();

            if (!builderlower.Contains("basic") && !builderlower.Contains("premium") && !builderlower.Contains("deluxe")
                && !this.AvailableBuilders.ContainsKey(BuilderName))
            {
                throw new ArgumentException("RatService builder unavailable or still not implemented.");
            }

            this.Builder = (IServiceBuilder)Activator.CreateInstance(this.AvailableBuilders[$"Rat{BuilderName}ServiceBuilder"]);

            this.Builder.CreateService();
            this.Builder.SetAssets();

            #region Validations
            var Service = this.Builder.Service as RatService;

            IService Result = null;
            if (builderlower.Contains("basic"))
            {
                Result = this.ValidateBasicService(Service);
            }
            else if (builderlower.Contains("premium"))
            {
                Result = this.ValidatePremiumService(Service);
            }
            else if (builderlower.Contains("deluxe"))
            {
                Result = this.ValidateDeluxeService(Service);
            }

            return Result;
            #endregion
        }

        #region Private Methods: Service Level Validators
        private IService ValidateBasicService(RatService Service)
        {
            var TempMask = Service.Assets.Where(x => x.GetNombreRecurso().Equals("SimpleMask")).SingleOrDefault();

            this.ValidatePoisonType(Service.Poison.Name);

            if (TempMask == null || TempMask.GetPrecioRecurso() > 20)
            {
                throw new Exception($"Not found or too much expensive mask in assets!");
            }
            else
            {
                return Service;
            }
        }

        private IService ValidatePremiumService(RatService Service)
        {
            var TempMasks = Service.Assets.Where(x => x.GetNombreRecurso().Equals("SimpleMask")).ToList();

            this.ValidatePoisonType(Service.Poison.Name);

            if (!TempMasks.Any() || TempMasks.Any(x => x.GetPrecioRecurso() > 200))
            {
                throw new Exception($"Not found or too much expensive mask in assets!");
            }
            else
            {
                return Service;
            }
        }

        private IService ValidateDeluxeService(RatService Service)
        {
            var TempSuit = Service.Assets.Where(x => x.GetNombreRecurso().Equals("ProtectionSuite")).ToList();
            var TempMask = Service.Assets.Where(x => x.GetNombreRecurso().Equals("SimpleMask")).ToList();
            var TempBleach = Service.Assets.Where(x => x.GetNombreRecurso().Equals("Bleach")).ToList();

            this.ValidatePoisonType(Service.Poison.Name);

            if (TempSuit == null || TempSuit.Any(x => x.GetPrecioRecurso() > 1000))
            {
                throw new Exception($"Not found or too much expensive protection suit in assets!");
            }
            else if (TempMask == null || TempMask.Any(x => x.GetPrecioRecurso() > 80))
            {
                throw new Exception($"Not found or too much expensive mask in assets!");
            }
            else if (TempBleach == null || TempBleach.Any(x => x.GetPrecioRecurso() > 500))
            {
                throw new Exception($"Not found or too much expensive bleach!");
            }
            else
            {
                return Service;
            }
        }
        #endregion

        #region Private Methods: Helpers
        private void ValidatePoisonType(string Name)
        {
            if (!"Arsenic".Equals(Name))
            {
                throw new Exception($"Wrong poison kind: It should be 'Arsenic', but it was {Name}!");
            }
        }

        private bool BuilderFilter(KeyValuePair<string, Type> Tuple)
        {
            var KeyMin = Tuple.Key.ToLower();

            return KeyMin.StartsWith("rat") && KeyMin.EndsWith("servicebuilder");
        }
        #endregion
    }
}
