﻿using System;

namespace ClubeDaLeitura.Domain
{
    public class BookLoan
    {
        private long _bookLoanId;
        public long BookLoanId
        {
            get { return _bookLoanId; }
            set { _bookLoanId = value; }
        }

        private Friend _borrowingFriend;
        public Friend BorrowingFriend
        {
            get { return _borrowingFriend; }
            set { _borrowingFriend = value; }
        }

        private ComicBook _borrowedComicBook;
        public ComicBook BorrowedComicBook
        {
            get { return _borrowedComicBook; }
            set { _borrowedComicBook = value; }
        }

        private DateTime _loanDate;
        public DateTime LoanDate
        {
            get { return _loanDate; }
            set { _loanDate = value; }
        }
        private DateTime? _returnDate;
        public DateTime? ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private bool _hasReturned;
        public bool HasReturned
        {
            get { return (ReturnDate != null); }
        }

        public BookLoan(Friend borrowingFriend, ComicBook borrowedComicBook)
        {
            BorrowingFriend = borrowingFriend;
            LoanDate = DateTime.Now;
            ReturnDate = null;

            if (borrowingFriend.FriendId > 0)
            {
                BorrowingFriend = borrowingFriend;
                BorrowingFriend.GetComicBook();
            }

            if (borrowedComicBook.ComicBookId > 0)
            {
                BorrowedComicBook = borrowedComicBook;
                BorrowedComicBook.Rent();
            }
        }

        public BookLoan(Friend borrowingFriend, ComicBook borrowedComicBook, double price) : this(borrowingFriend, borrowedComicBook)
        {
            Price = price;
        }

        public BookLoan()
        {
            BorrowingFriend = new Friend();
            BorrowedComicBook = new ComicBook();
        }

        public void EndLoan()
        {
            ReturnDate = DateTime.Now;
            BorrowedComicBook.Return();
            BorrowingFriend.ReturnComicBook();
        }

        public override string ToString()
        {
            return $"{BookLoanId} - Amigo: {BorrowingFriend.Name} - Revista: {BorrowedComicBook.CollectionType} nº {BorrowedComicBook.EditionNumber} ano {BorrowedComicBook.ComicBookYear} - Preço: R$ {Price} - Empréstimo: {LoanDate.ToShortDateString()} - Devolução: {ReturnDate?.ToShortDateString()}";
        }
    }
}
