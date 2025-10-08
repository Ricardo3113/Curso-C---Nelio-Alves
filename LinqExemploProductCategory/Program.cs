using System;
using System.Linq;
using System.Collections.Generic;
using LinqExemploProductCategory.Entities;

namespace LinqExemploProductCategory {
    class Program {
        //função auxiliar para imprimir os resultados 
        static void Print<T>(string message, IEnumerable<T> collection) {
            Console.WriteLine(message);

            foreach (T obj in collection) {
                Console.WriteLine(obj);
            }            
            Console.WriteLine();            
        } 


        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.00, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.00, Category= c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.00, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.00, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.00, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.00, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.00, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.00, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.00, Category = c2 },
                new Product() { Id = 10, Name = "Soud Bar", Price = 700.00, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.00, Category = c1 }
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price <= 900.00);
            Print("TIER 1 AND PRICE < 900: ", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS: ", r2);

            //No var 3, foi filtrado por nome, preço e categoria usando select e
            //criado um objeto anonimo(expecifico) para esse filtro com uso de expressão lambda
            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED MITH 'C' AND ANONYMOUS OBJETC", r3); 

            //produtos cujos tier da categoria sejam 1 ordenados por preços e por nomes
            var r4 = products.Where(p => p.Category.Tier == 1)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name);
            Print("TIER 1 ORDERED BY PRICE THEN BY NAME", r4);

            //exemplo de skip e take(funções para paginação) reutilizando o resultado de r4
            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDERED BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = products.First();
            Console.WriteLine("First test one" + r6);

            //da erro porque a coleção esta vazia...nao tem produto com preço maior que 3000
            //para tratar esse erro usase FirstorDefault para retornar valor nulo nesse caso
            var r7 = products.Where(p => p.Price > 3000.00).FirstOrDefault();
            Console.WriteLine("First teste two" + r7);
            Console.WriteLine();

            //singleordefault usase apena qdo tem certeza de q retorna um vlaor ou nenhum, se tiver mais 
            //ressultados para, por exemplo id==3 da erro
            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or Default test one: " + r8);

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or Default test two: " + r9);
            Console.WriteLine();

            //OPERAÇÕES PRÉ DEFINIDAS
            //se passar products.max vazio, vai dar erro, precisa especificar um atributo
            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max Price: " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min Price: " + r11);
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 sum prices: " + r12);
            var r13 = products.Where(p => p.Category.Id == 2).Average(p => p.Price);
            Console.WriteLine("Category 2 average prices: " + r13);
            Console.WriteLine();
            //tratamento para qdo a categoria não existe e average retorna nulo,
            //atribuindo 0 como valor default e então chamando a função average
            var r14 = products.Where(p => p.Category.Id == 5)
                .Select(p => p.Price)
                .DefaultIfEmpty(0.0)
                .Average();
            Console.WriteLine("Category 5 average prices: " + r14);

            //OPERAÇÕES CUSTOMIZADAS - PERSONALIZADAS - MAP REDUCE - SELECT AGREGATE
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Category 1 aggregate sum: " + r15);
            Console.WriteLine();

            //OPERAÇÃO DE AGRUPAMENTO
            var r16 = products.GroupBy(p => p.Category);
            //para imprimir os valores precisa de foreach especifico para o tipo igroupping que é uma tupla contendo chave e coleção 
            foreach (IGrouping<Category, Product> group in r16) {
                Console.WriteLine("Category " + group.Key.Name + " : ");
                foreach (Product p in group) {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}
