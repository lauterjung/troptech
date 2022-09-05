using System;
using SalaReunioes.Domain.Exceptions;

namespace SalaReunioes.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public Room ReservationRoom { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Employee ReservationEmployee { get; set; }

        public Reservation(Room reservationRoom, DateTime startDateTime, DateTime endDateTime, Employee reservationEmployee)
        {
            ReservationRoom = reservationRoom;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ReservationEmployee = reservationEmployee;

            if (StartDateTime > EndDateTime || StartDateTime < DateTime.Today)
            {
                throw new InvalidDateTimeException();
            }
        }

        public Reservation()
        {
            ReservationRoom = new Room();
            ReservationEmployee = new Employee();
        }

        public override string ToString()
        {
            return $"{Id} - {ReservationRoom.Name} - Início: {StartDateTime} - Fim: {EndDateTime} - Funcionário: {ReservationEmployee.Name}";
        }
    }
}