using System;
using System.Collections.Generic;
using SalaReunioes.Domain;
using SalaReunioes.Domain.Exceptions;
using SalaReunioes.Infra.Data.DAO;

namespace SalaReunioes.Infra.Data
{
    public class RoomRepository : IRoomRepository
    {
        private RoomDAO _roomDAO = new RoomDAO();

        public List<Room> SearchAllRooms()
        {
            List<Room> roomList = _roomDAO.SearchAllRooms();

            if (roomList.Count == 0)
            {
                throw new ZeroRoomsRegistered();
            }

            return roomList;
        }

        public Room searchRoomByName(string roomName)
        {
            Room room = _roomDAO.searchRoomByName(roomName);

            if (room is null)
            {
                throw new InexistingAvailableRoom();
            }

            return room;
        }
    }
}