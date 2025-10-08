//SOLUÇÃO BOA COLOCANDO AS REGRAS DA CLASSE NA PRÓPRIA CLASSE
//E FAZENDO TRATAMENTO DE EXCESSÕES 

using System;
using ProblemaExemploReservation.Entities;
using ProblemaExemploReservation.Entities.Exceptions;

namespace ProblemaExemploReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reservation.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reservatiom: " + reservation);
            }

            catch (DomainException e)
            {
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}



/* SOLUÇÃO INEFICIENTE PORQUE AS REGRAS ESTÃO NO PROGRAMA PRINCIPAL, 
 *SEM TRATAMENTO DE EXCEÇÕES E OUTRAS RAZÕES TBM
 * 
 *  
using System;
using ProblemaExemploReservation.Entities;

namespace ProblemaExemploReservation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Room Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            if (checkOut <= checkIn)
            {
                Console.WriteLine("Error in reservation: Check-out must be after Check-in date");
            }
            else
            {
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                //teste pra verificar data da reserva é menor que data atual
                DateTime now = DateTime.Now;
                if (checkIn < now || checkOut < now)
                {
                    Console.WriteLine("Error in reservation: Reservation dates for update must be future dates");
                }

                //depois do teste inicial precisa testar a condição de checkout ser maior que o checkin 
                else if (checkOut <= checkIn)
                {
                    Console.WriteLine("Error in reservation: Check-out must be after Check-in date");
                }
                else
                {
                    reservation.UpdateDates(checkIn, checkOut);
                    Console.WriteLine("Reservatiom: " + reservation);
                }
            }
        }
    }
}
*/


/*
 * 
 * codigo com auxilio do GPT...roda sem problemas e resolve o problema do date.now....que dá erro 
 * se simular com datas antigas, como as usadas no exemplo 
 * 
using System;
using ProblemaExemploReservation.Entities;

namespace ProblemaExemploReservation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Room Number: ");
            int number = int.Parse(Console.ReadLine());

            // Entrada inicial
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = ReadDate();
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = ReadDate();

            // Validação inicial (apenas para verificar se o Check-out é depois do Check-in)
            if (checkOut <= checkIn)
            {
                Console.WriteLine("Error: Check-out must be after Check-in date.");
                return;
            }

            // Criação da reserva
            Reservation reservation = new Reservation(number, checkIn, checkOut);
            Console.WriteLine("Reservation: " + reservation);

            // Atualização da reserva
            Console.WriteLine("\nEnter data to update the reservation:");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkIn = ReadDate();
            Console.Write("Check-out date (dd/MM/yyyy): ");
            checkOut = ReadDate();

            // Validação para atualização
            if (checkOut <= checkIn)
            {
                Console.WriteLine("Error: Check-out must be after Check-in date.");
                return;
            }

            reservation.UpdateDates(checkIn, checkOut);
            Console.WriteLine("Updated Reservation: " + reservation);
        }

        // Método simples para ler e validar a data
        static DateTime ReadDate()
        {
            while (true)
            {
                try
                {
                    return DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Write("Invalid date format. Please enter a valid date (dd/MM/yyyy): ");
                }
            }
        }
    }
}
*/
