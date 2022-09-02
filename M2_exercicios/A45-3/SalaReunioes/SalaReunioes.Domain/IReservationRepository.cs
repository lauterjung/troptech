using System.Collections.Generic;

namespace SalaReunioes.Domain
{
    public interface IReservationRepository
    {
        public void AddReservation(Reservation reservation);
        public List<Reservation> SearchAllReservations();
    }
}