/*  PROBLEMA 
 *  
 *  Uma empresa de consultoria deseja avaliar a performance de produtos,
 *  funcionários, dentre outras coisas. Um dos cálculos que ela precisa é encontrar
 *  o maior dentre um conjunto de elementos. Fazer um programa que leia um
 *  conjunto de N produtos, conforme exemplo, e depois mostre o mais caro deles.
 *  ----------------------------------------------------------------------------------
 *  EXEMPLO:
 *  
 *  Enter the number of products: 3
 *  
 *  Computer,890.50
 *  IPhone X,910.00
 *  Tablet,550.00
 *  
 *  Max:
 *  IPhone, 910.00   
 *  
 */

using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;
using Course.Services;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
                list.Add(new Product(vect[0], price));
            }

            CalculationService calculationService = new CalculationService();

            Product p = calculationService.Max(list); // <Product> is optional

            Console.WriteLine("Most expensive:");
            Console.WriteLine(p);
        }
    }
}