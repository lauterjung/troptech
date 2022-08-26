using System.Collections.Generic;

namespace ClubeDaLeitura.Domain
{
    public interface IComicBookRepository
    {
        void AddComicBook(ComicBook comicBook);
        List<ComicBook> SearchAllComicBooks();
    }
}
