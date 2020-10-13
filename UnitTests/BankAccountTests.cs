using Microsoft.VisualStudio.TestTools.UnitTesting;
using bank_unit_testing;
using System;

namespace Bank.Tests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Deposit_WithValidAmount_UpdatesBalance()
        {
            var Mock_account = new BankAccount("Mok",10);

            Mock_account.Deposit(10);

            Assert.AreEqual(20, Mock_account.Balance, "not equal");
        }

        [TestMethod]
        public void Deposit_WithInvalidAmount_ThrowsArgumentOutOfRangeException()
        {
            var Mock_account = new BankAccount("Mok", 10);

            Assert.ThrowsException<ArgumentOutOfRangeException>( () => Mock_account.Deposit(-10) );
        }

        [DataRow(10,10,20)]
        [DataRow(5,15,20)]
        [DataRow(15,5,20)]
        [DataTestMethod]
        public void WithDraw_WithVvalidAmount_UpdatesBalance(int amount,int expected,int init)
        {
            var Mock_account = new BankAccount("Mok", init);
            Mock_account.WithDraw(amount);
            Console.WriteLine(amount + " " + Mock_account.Balance);
            Assert.AreEqual(expected, Mock_account.Balance, "not equal");
        }

        [DataRow("", 10)]
        [DataTestMethod]
        public void Ctor_InvalidArguments_ArgumentException(string name,int initial_val)
        {
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(name,initial_val));
        }
    }
}
