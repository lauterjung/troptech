using System.Collections.Generic;

namespace SalaReunioes.Domain
{
    public interface IRoomRepository
    {
        public List<Room> SearchAllRooms();
        public Room searchRoomByName(string roomName);
    }
}