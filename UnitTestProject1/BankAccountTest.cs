using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;


namespace BankTests
{

    [TestClass]

    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_ValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginingBalance = 11.99;
            double debitAmount = -20.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginingBalance);
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
            }

            account.Debit(debitAmount);


        }
        [TestMethod]

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreBalance_ShouldThrowArgumentsOutofRange()
        {
            double beginingBalance = 11.99;
            double debitAmount = 21.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginingBalance);
            
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            
            Assert.Fail("The expected exception was is not thrown.");

            
        }


    }

}
