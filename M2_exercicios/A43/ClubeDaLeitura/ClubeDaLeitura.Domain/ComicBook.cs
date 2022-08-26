using System;
using ClubeDaLeitura.Domain.Exceptions;

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

        private BoxColors _boxColor;
        public BoxColors BoxColor
        {
            get { return _boxColor; }
            set { _boxColor = value; }
        }

        private bool _isLocated;
        public bool IsLocated
        {
            get { return _isLocated; }
            set { _isLocated = value; }
        }


        public ComicBook(string collectionType, int editionNumber, int comicBookYear, BoxColors boxColor)
        {
            CollectionType = collectionType;
            EditionNumber = editionNumber;
            ComicBookYear = comicBookYear;
            BoxColor = boxColor;
            IsLocated = false;
        }

        public ComicBook()
        {
            
        }

        public void Rent()
        {
            if(IsLocated == true)
            {
                throw new UnavailableComicBook();
            }

            IsLocated = true;
        }

        public void Return()
        {
            IsLocated = false;
        }

        public override string ToString()
        {
            return $"{ComicBookId} - {CollectionType} - nº {EditionNumber} - ano {ComicBookYear} - Caixa {BoxColor.ToString()} - Locada? {(IsLocated ? "Sim" : "Não")}";
        }
    }
}
