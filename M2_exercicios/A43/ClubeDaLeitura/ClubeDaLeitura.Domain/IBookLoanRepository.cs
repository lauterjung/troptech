using System.Collections.Generic;

namespace ClubeDaLeitura.Domain
{
    public interface IBookLoanRepository
    {
        void AddBookLoan(string friendName, string comicBookCollectionType, string comicBookYear, string comicBookEditionNumber); 
        List<BookLoan> SearchAllBookLoans();
        void EndLoan(BookLoan bookLoan); 
    }
}
