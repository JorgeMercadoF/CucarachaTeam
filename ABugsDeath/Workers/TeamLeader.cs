using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABugsDeath.Workers
{
    public class TeamLeader : WorkerBase
    {
        #region Public Attributes
        public List<WorkerBase> Team;
        #endregion

        #region Public Properties
        public override decimal Price
        {
            get
            {
                var Total = 0m;

                foreach (var Worker in this.Team)
                {
                    Total += Worker.Price;
                }

                return Total + this.Salary;
            }
        }
        #endregion

        #region Constructor
        public TeamLeader(decimal Salary) : base(Salary)
        {
            this.Team = new List<WorkerBase>();
        }
        #endregion

        #region Public Methods
        public override void AddWorker(WorkerBase Worker)
        {
            if (Worker is TeamLeader)
            {
                throw new ArgumentException("A Team Leader can't command another Team Leader.");
            }
            else if (this.Team.Count >= 3)
            {
                throw new Exception("A Team Leader can't hold more than 3 workers at a time.");
            }
            else
            {
                this.Team.Add(Worker);
            }
        }

        public override WorkerBase GetWorker(int Index)
        {
            if (Index < 0)
            {
                throw new ArgumentException("No negatives allowed.");
            }
            else if (!this.Team.Any() || Index >= this.Team.Count)
            {
                throw new ArgumentException("The requested worker doesn't exist yet.");
            }
            else
            {
                return this.Team[Index];
            }
        }

        public override bool RemoveWorker(WorkerBase Worker)
        {
            return this.Team.Remove(Worker);
        }
        #endregion
    }
}
