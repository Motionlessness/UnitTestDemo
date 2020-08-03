using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        /// <summary>
        /// deposits the amount in the bank account and returns the new balance
        /// </summary>
        /// <param name="amt">the amount to deposit</param>
        /// <returns></returns>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} must be a positive amount");
            }
            if (amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be smaller than 10,000");
            }

            Balance += amt;
            return Balance;
        }

         public double Withdraw(double amt)
         {
            if (amt > Balance) {
                throw new ArgumentException("You cannot withdraw more than the current balance");
            }
            if (amt <= 0)
            {
                throw new ArgumentException($"{nameof(amt)} must be a positive amount");
            }
            Balance -= amt;
            return Balance;
         }

        public double Balance { get; private set; }
    }
}
