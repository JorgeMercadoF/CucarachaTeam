using ABugsDeath.Interfaces;
using System;

namespace ABugsDeath
{
    public abstract class WorkerBase : ICost
    {
        #region Private Attributes
        protected decimal Salary;
        #endregion

        #region Public Properties
        public string Name { get; set; }

        public abstract decimal Price { get; }
        #endregion

        #region Constructor
        public WorkerBase(decimal Salary)
        {
            if (Salary <= 0)
            {
                throw new ArgumentException("A worker must have a higher-than-zero salary!");
            }
            else
            {
                this.Salary = Salary;
            }
        }
        #endregion

        #region Public Methods: Composite Methods
        public virtual void AddWorker(WorkerBase Worker)
        {
            throw new NotSupportedException("This worker can't have workers.");
        }

        public virtual WorkerBase GetWorker(int Index)
        {
            throw new NotSupportedException("This worker can't have workers.");
        }

        public virtual bool RemoveWorker(WorkerBase Worker)
        {
            throw new NotSupportedException("This worker can't have workers.");
        }
        #endregion
    }
}
