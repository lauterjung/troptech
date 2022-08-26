using System.Collections.Generic;

namespace ClubeDaLeitura.Domain
{
    public interface IFriendRepository
    {
        void AddFriend(Friend friend);
        List<Friend> SearchAllFriends();
    }
}
