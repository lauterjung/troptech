using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;

namespace ClubeDaLeitura.Infra.Data
{
    public class BookLoanRepository : IBookLoanRepository
    {
        private BookLoanDAO _bookLoanDAO = new BookLoanDAO();
        private FriendDAO _friendDAO = new FriendDAO();
        private ComicBookDAO _comicBookDAO = new ComicBookDAO();

        public void AddBookLoan(string friendName, string comicBookCollectionType, string comicBookYear, string comicBookEditionNumber)
        {
            Friend friend = _friendDAO.SearchFriendByName(friendName);
            if (friend.FriendId == 0)
            {
                throw new FriendNotFound();
            }

            ComicBook comicBook = _comicBookDAO.SearchComicBookByParameters(comicBookCollectionType, comicBookYear, comicBookEditionNumber);

            if (comicBook.ComicBookId == 0)
            {
                throw new ComicBookNotFound();
            }

            BookLoan bookLoan = new BookLoan(friend, comicBook);
            _bookLoanDAO.AddBookLoan(bookLoan);
        }

        public List<BookLoan> SearchAllBookLoans()
        {
            List<BookLoan> bookLoanList = _bookLoanDAO.SearchAllBookLoans();

            if (bookLoanList.Count == 0)
            {
                throw new ZeroBookLoansRegistered();
            }

            return bookLoanList;
        }
    }
}
