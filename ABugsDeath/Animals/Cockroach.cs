using ABugsDeath.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Animals
{
    public class Cockroach : IAnimal
    {
        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
