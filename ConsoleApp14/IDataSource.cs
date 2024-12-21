using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6ProgrammingTechnologes
{
    public interface IDataSource
    {
        public float GetBalance(string accountNumber);
        public void SetBalance(string accountNumber, float amount);
        public bool IsUserExists(string accountNumber);
        public void AddUser(string accountNumber);
    }
}
