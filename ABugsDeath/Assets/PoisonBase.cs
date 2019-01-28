using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Assets
{
    public class PoisonBase : IRecurso
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public PoisonBase(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string GetNombreRecurso()
        {
            return Name;
        }

        public decimal GetPrecioRecurso()
        {
            return Price;
        }
    }
}
