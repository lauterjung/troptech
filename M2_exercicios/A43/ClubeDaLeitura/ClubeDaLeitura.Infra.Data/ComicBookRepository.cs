using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;

namespace ClubeDaLeitura.Infra.Data
{
    public class ComicBookRepository : IComicBookRepository
    {
        private ComicBookDAO _comicBookDAO = new ComicBookDAO();

        public void AddComicBook(ComicBook comicBook)
        {
            _comicBookDAO.AddComicBook(comicBook);
        }

        public List<ComicBook> SearchAllComicBooks()
        {
            List<ComicBook> comicBookList = _comicBookDAO.SearchAllComicBooks();

            if (comicBookList.Count == 0)
            {
                throw new ZeroComicBooksRegistered();
            }
            
            return comicBookList;            
        }
    }
}
