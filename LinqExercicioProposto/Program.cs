using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using LinqExercicioProposto.Entities;

namespace LinqExercicioProposto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the full file path: "  );
            string path = Console.ReadLine();

            List<Product> list = new List<Product>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    //vetor fields recebe função split para separalo em dois campos
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    list.Add(new Product(name, price));
                }
            }
            
            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average Price = " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var names = list.Where(p => p.Price < avg)
                .OrderByDescending(p => p.Name)
                .Select(p => p.Name);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
