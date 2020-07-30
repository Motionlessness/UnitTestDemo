using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    { 
        private double _balance;

        /// <summary>
        /// deposits the amount in the bank account and returns the new balance
        /// </summary>
        /// <param name="amt">the amount to deposit</param>
        /// <returns></returns>
        public double Deposit(double amt)
        {
            _balance += amt;
            return _balance;
        }

         public double Withdraw(double amt)
         {
            _balance -= amt;
            return _balance;
         }
            
    }
}
