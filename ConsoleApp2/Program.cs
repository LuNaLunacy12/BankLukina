using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountNS;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double beginingBalance = 11.99;
            double debitAmount = 21.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginingBalance);

            try
            {
                account.Debit(debitAmount);
                //Assert.Fail("The expected exception was is not thrown.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                //StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
        }
    }
}
