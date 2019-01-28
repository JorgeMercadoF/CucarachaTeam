using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Workers
{
    public class Worker : WorkerBase
    {
        #region Public Properties
        public override decimal Price => this.Salary;
        #endregion

        #region Constructor
        public Worker(decimal Salary) : base(Salary) { }
        #endregion
    }
}
