using System;

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

        public Reservation MakeReservation(DateTime start, DateTime end, string employeeName)
        {
            Reservation reservation = new Reservation(this, start, end, employeeName);
            return reservation;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {NumberOfSeats} lugares";
        }
    }
}
