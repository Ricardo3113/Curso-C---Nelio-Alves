using System;
using heranca_polimorfismo_exemplo_account.Entities;

namespace heranca_polimorfismo_exemplo_account
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account(1001, "Alex", 1000.00);
            Account acc2 = new SavingsAccount(1002, "Maria", 2000.00, 0.01);

            acc1.Withdraw(300.00);
            acc2.Withdraw(500.00);

            Console.WriteLine("R$" + acc1.Balance);
            Console.WriteLine("R$" + acc2.Balance);
        }
    }
}
