using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6ProgrammingTechnologes
{
    public class Database : IDataSource
    {
        Dictionary<string, float> data = new Dictionary<string, float>();

        public void AddUser(string accountNumber)
        {
            data.Add(accountNumber, 0);
        }

        public float GetBalance(string accountNumber)
        {
            return data[accountNumber];
        }

        public bool IsUserExists(string accountNumber)
        {
            return data.ContainsKey(accountNumber);
        }

        public void SetBalance(string accountNumber, float amount)
        {
            data[accountNumber] = amount;
        }
    }
}
