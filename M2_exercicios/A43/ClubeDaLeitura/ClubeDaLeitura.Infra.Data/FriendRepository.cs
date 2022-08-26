using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;

namespace ClubeDaLeitura.Infra.Data
{
    public class FriendRepository : IFriendRepository
    {
        private FriendDAO _friendDAO = new FriendDAO();
        private ComicBookDAO _comicBookDAO = new ComicBookDAO();

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

        public List<ComicBook> GenerateComicBooksReport(string friendName)
        {
            _friendDAO.SearchFriendByName(friendName);
            List<ComicBook> comicBookList = _comicBookDAO.GenerateReportByFriend(friendName);

            if (comicBookList.Count == 0)
            {
                throw new ZeroFriendsRegistered();
            }

            return comicBookList;
        }
    }
}
