using System;
using System.Globalization;
using Exercicio_fixacao_paypal.Entities;
using Exercicio_fixacao_paypal.Services;

namespace Exercicio_fixacao_paypal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data:");
            Console.Write("Number: ");
            int contractNumer = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);//mascara de formatação, só aceita data no formato "dd/MM/yyyy"
            Console.Write("Contract Value: ");
            double contactValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter the number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(contractNumer, contractDate, contactValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, months);

            Console.WriteLine("Installments:");
            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
