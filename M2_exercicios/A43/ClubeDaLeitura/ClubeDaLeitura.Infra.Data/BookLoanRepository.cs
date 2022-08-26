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
            _comicBookDAO.UpdateComicBook(comicBook);
            _friendDAO.UpdateFriend(friend);
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

        public BookLoan SearchBookLoanByComicBookParameters(string collectionType, string comicBookYear, string editionNumber)
        {
            BookLoan bookLoan = _bookLoanDAO.SearchBookLoanByComicBookParameters(collectionType, comicBookYear, editionNumber);

            if (bookLoan is null)
            {
                throw new BookLoanNotFound();
            }

            return bookLoan;
        }

        public void EndLoan(BookLoan bookLoan)
        {
            _bookLoanDAO.UpdateBookLoan(bookLoan);

            Friend friend = _friendDAO.SearchFriendById(bookLoan.BorrowingFriend.FriendId.ToString());
            friend.HasActiveLoan = bookLoan.BorrowingFriend.HasActiveLoan;
            _friendDAO.UpdateFriend(friend);
            
            ComicBook comicBook = _comicBookDAO.SearchComicBookById(bookLoan.BorrowedComicBook.ComicBookId.ToString());
            comicBook.IsLocated = bookLoan.BorrowedComicBook.IsLocated;
            _comicBookDAO.UpdateComicBook(comicBook);
        }
    }
}
