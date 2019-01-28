using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Workers
{
    public class BusinessManager : WorkerBase
    {
        #region Private Attributes
        private List<WorkerBase> Workers;
        #endregion

        #region Public Properties
        public override decimal Price
        {
            get
            {
                var Total = 0m;

                foreach (var Worker in this.Workers)
                {
                    Total += Worker.Price;
                }

                return Total + this.Salary;
            }
        }
        #endregion

        #region Constructor
        public BusinessManager(decimal Salary) : base(Salary)
        {
            this.Workers = new List<WorkerBase>();
        }
        #endregion

        #region Public Methods
        public override void AddWorker(WorkerBase Worker)
        {
            this.Workers.Add(Worker);
        }

        public override WorkerBase GetWorker(int Index)
        {
            return this.Workers[Index];
        }

        public override bool RemoveWorker(WorkerBase Worker)
        {
            return this.Workers.Remove(Worker);
        }
        #endregion
    }
}
