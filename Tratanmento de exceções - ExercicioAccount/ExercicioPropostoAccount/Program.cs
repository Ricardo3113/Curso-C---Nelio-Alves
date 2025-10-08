using System;
using ExercicioPropostoAccount.Entities;
using ExercicioPropostoAccount.Entities.Exceptions;
using System.Globalization;


namespace ExercicioPropostoAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter account data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial Balance: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw Limit: ");
            double withdrawlimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, balance, withdrawlimit);

            Console.WriteLine();
            Console.Write("Enter amount for withdraw: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            try
            {
                account.WithDraw(amount);
                Console.WriteLine("New Balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainException e) 
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }
        }
    }
}
