using System;

namespace SalaReunioes.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public Room ReservationRoom { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string EmployeeName { get; set; }

        public Reservation(Room reservationRoom, DateTime startDateTime, DateTime endDateTime, string employeeName)
        {
            ReservationRoom = reservationRoom;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            EmployeeName = employeeName;
        }

        public Reservation()
        {
            ReservationRoom = new Room();
        }

        public override string ToString()
        {
            return $"{ReservationRoom.Name} - Início: {StartDateTime} - Fim: {EndDateTime} - Funcionário: {EmployeeName}";
        }
    }
}