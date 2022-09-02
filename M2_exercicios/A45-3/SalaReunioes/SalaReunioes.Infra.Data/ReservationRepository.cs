using System;
using System.Collections.Generic;
using SalaReunioes.Domain;
using SalaReunioes.Domain.Exceptions;
using SalaReunioes.Infra.Data.DAO;

namespace SalaReunioes.Infra.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private ReservationDAO _reservationDAO = new ReservationDAO();

        public void AddReservation(Reservation reservation)
        {
            _reservationDAO.AddReservation(reservation);
        }

        public List<Reservation> SearchAllReservations()
        {
            List<Reservation> reservationList = _reservationDAO.SearchAllReservations();

            if (reservationList.Count == 0)
            {
                throw new ZeroReservationsRegistered();
            }

            return reservationList;
        }
    }
}