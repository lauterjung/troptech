using System;

namespace ClubeDaLeitura.Domain
{
    public class ComicBook
    {

        private float _comicBookId;
        public float ComicBookId
        {
            get { return _comicBookId; }
            set { _comicBookId = value; }
        }

        private string _collectionType;
        public string CollectionType
        {
            get { return _collectionType; }
            set { _collectionType = value; }
        }

        private int _editionNumber;
        public int EditionNumber
        {
            get { return _editionNumber; }
            set { _editionNumber = value; }
        }

        private int _comicBookYear;
        public int ComicBookYear
        {
            get { return _comicBookYear; }
            set { _comicBookYear = value; }
        }

        private string _boxColor;
        public string BoxColor
        {
            get { return _boxColor; }
            set { _boxColor = value; }
        }

        public ComicBook(string collectionType, int editionNumber, int comicBookYear, string boxColor)
        {
            CollectionType = collectionType;
            EditionNumber = editionNumber;
            ComicBookYear = comicBookYear;
            BoxColor = boxColor;
        }

        public ComicBook()
        {

        }

        public override string ToString()
        {
            return $"{ComicBookId} - {CollectionType} - nº {EditionNumber} - ano {ComicBookYear} - Caixa {BoxColor}";
        }
    }
}
