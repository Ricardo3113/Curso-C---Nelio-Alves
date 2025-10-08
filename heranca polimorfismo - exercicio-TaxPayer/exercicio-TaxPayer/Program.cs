using System;
using System.Globalization;
using System.Collections.Generic;
using exercicio_TaxPayer.Entities;

namespace exercicio_TaxPayer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");                
                
                Console.Write("Individual or company (i/c)? ");                
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");                
                string name = Console.ReadLine();
                
                Console.Write("Anual Income: ");
                double income = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                //VERIFICAÇÃO DO TIPO DE IMPOSTO
                if (ch == 'i') //INDIVIDUAL = CPF
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, income, healthExpenditures));
                }
                else //COMPANY = JURIDICO = CNPJ
                {
                    Console.Write("Number of Employess: ");
                    int numberOfEmployess = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, income, numberOfEmployess));
                }
            }

            //SOMATÓRIO DOS IMPOSTOS
            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach (TaxPayer taxpayer in list)
            {
                double tax = taxpayer.Tax();
                Console.WriteLine(taxpayer.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
                sum += tax;
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));            
        }
    }
}
