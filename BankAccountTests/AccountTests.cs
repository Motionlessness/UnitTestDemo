using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void Initialize() 
        {
            acc = new Account();
        }

        [TestMethod]
        [TestCategory("Deposits")]
        [DataRow(10_000)]
        [DataRow(double.MaxValue)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            Account acc = new Account();
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
        }

        [TestMethod()]
        [TestCategory("Deposits")]
        [DataRow(100)]
        [DataRow(0.01)]
        [DataRow(9999.99)]

        public void Deposit_PositiveAmount_AddsToBalance(double initDeposit)
        {
            // AAA - ARRANGE Act Assert

            //arrange
            //Account acc = new Account();
            const double startBalance = 0;

            //act
            acc.Deposit(initDeposit);

            //assert
            Assert.AreEqual(startBalance + initDeposit, acc.Balance);
        }
    
        [TestMethod()]
        [TestCategory("Deposits")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            //Account acc = new Account();
            const double initialBal = 0;
            const double depoistAmount = 10.55;

            double newBalance = acc.Deposit(depoistAmount);

            Assert.AreEqual(initialBal + depoistAmount, newBalance);
        }

        [TestMethod()]
        [TestCategory("Deposits")]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            //Account acc = new Account();
            double depo = 10;
            double depo1 = 25;
            double expectedBalance = depo + depo1;


            acc.Deposit(depo);
            double finalBalance = acc.Deposit(depo1);

            Assert.AreEqual(expectedBalance, finalBalance);
        }

        [TestMethod]
        [TestCategory("Deposits")]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            //Account acc = new Account();
            double negDepo = -1;

            // Assert => Act
            Assert.ThrowsException<ArgumentException>( () => acc.Deposit(negDepo) );

        }


        [TestMethod]
        [TestCategory("Withdraws")]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(1, 0.5)]

        public void Widraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {

            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Withdraws")]
        public void Widraw_MoreThanBalance_ThrowsArgumentException()
        {
            Account myaccount = new Account();
            double withdrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>( () => myaccount.Withdraw(withdrawAmount) );
        }

        [TestMethod]
        [TestCategory("Withdraws")]
        public void Widraw_NegativeAmount_ThrowsArgumentException()
        {
            Account myaccount = new Account();
            double withdrawNegative = -1;

            Assert.ThrowsException<ArgumentException>( () => myaccount.Withdraw(withdrawNegative) );
        }
    }
}