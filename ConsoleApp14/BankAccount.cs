using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6ProgrammingTechnologes
{
    public class BankAccount
    {
        private string accountNumber;
        private IDataSource dataSource;
        public BankAccount(string accountNumber, IDataSource dataSource, float balance = 0)
        {
            this.accountNumber = accountNumber;
            this.dataSource = dataSource;
            if (!dataSource.IsUserExists(accountNumber)) 
            { 
                dataSource.AddUser(accountNumber);
                if (balance >= 0)
                {
                    dataSource.SetBalance(accountNumber, balance);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            
            
        }
        public void Deposit(float amount)
        {
            if (amount > 0)
            {
                dataSource.SetBalance(accountNumber,dataSource.GetBalance(accountNumber) + amount);
            }
            else
            {
                throw new ValueError();
            }
        }
        public float GetBalance()
        {
            return dataSource.GetBalance(accountNumber);
        }
        public void Withdraw(float amount)
        {
            if (amount <= 0)
            {
                throw new ValueError();
            }
            else if (amount > dataSource.GetBalance(accountNumber))
            {
                throw new ValueError("Insufficient funds");
            }
            else
            {
                dataSource.SetBalance(accountNumber, dataSource.GetBalance(accountNumber) - amount);
            }
        }
    }
}
