using System;
using ProblemaExemploReservation.Entities.Exceptions;

namespace ProblemaExemploReservation.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public Reservation() 
        {
        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Check-out must be after Check-in date");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration() 
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            //TimeSpan duration = CheckOut - CheckIn;
            return (int)duration.TotalDays;
        }
        
        //atualização dos parametros checkin e ceckou depois da operação duration 
        //os atributos iniciados mais acima são atualizados depois da chamada do reservation no programa principal 
        public void UpdateDates (DateTime checkIn, DateTime checkOut) 
        {
            //teste pra verificar data da reserva é menor que data atual
            DateTime now = DateTime.Now;
            //se a data for menor que a atual uma exceção deve ser lançada
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            //depois do teste inicial precisa testar a condição de checkout ser maior que o checkin 
            if (checkOut <= checkIn)
            {
                throw new DomainException("Check-out must be after Check-in date");
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return "Room " 
                + RoomNumber
                + ", check -in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check -out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", " 
                + Duration()
                + " nights";
        }
    }
}