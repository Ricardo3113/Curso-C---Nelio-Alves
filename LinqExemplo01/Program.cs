using System;
using System.Linq;

namespace LinqExemplo01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Specify the data source
            int[] numbers = new int[] { 2, 3, 4, 5, 6, 7, 8 };

            //Define the query expression(no caso, separar os numeros pares e multiplicar por 10)
            var result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10);

            //Execute the query
            foreach (int x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}
