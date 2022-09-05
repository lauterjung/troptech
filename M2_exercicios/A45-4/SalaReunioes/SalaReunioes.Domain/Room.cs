using System;
using System.Collections.Generic;
using System.Linq;
using SalaReunioes.Domain.Exceptions;

namespace SalaReunioes.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public AvailableRooms Name { get; set; }
        public int NumberOfSeats { get; set; }

        public Room(int id, AvailableRooms name, int numberOfSeats)
        {
            Id = id;
            Name = name;
            NumberOfSeats = numberOfSeats;
        }

        public Room()
        {

        }

        public Reservation MakeReservation(DateTime start, DateTime end, Employee employee, List<Reservation> reservationList)
        {
            if (reservationList.Any(x => (x.ReservationRoom.Id == Id) &&
                ((x.StartDateTime < start && x.EndDateTime > start) ||
                (x.StartDateTime < end && x.EndDateTime > end))
                ))
            {
                throw new RoomAlreadyBooked();
            }
            Reservation reservation = new Reservation(this, start, end, employee);
            return reservation;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {NumberOfSeats} lugares";
        }
    }
}
