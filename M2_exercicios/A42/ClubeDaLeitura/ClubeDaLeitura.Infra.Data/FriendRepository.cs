using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;

namespace ClubeDaLeitura.Infra.Data
{
    public class FriendRepository : IFriendRepository
    {
        private FriendDAO _friendDAO = new FriendDAO();

        public void AddFriend(Friend friend)
        {
            _friendDAO.AddFriend(friend);
        }

        public List<Friend> SearchAllFriends()
        {
            List<Friend> friendList = _friendDAO.SearchAllFriends();

            if (friendList.Count == 0)
            {
                throw new ZeroFriendsRegistered();
            }
            
            return friendList;            
        }
    }
}
