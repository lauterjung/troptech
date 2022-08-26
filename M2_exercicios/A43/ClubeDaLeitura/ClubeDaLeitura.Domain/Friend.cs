using System;
using ClubeDaLeitura.Domain.Exceptions;

namespace ClubeDaLeitura.Domain
{
    public class Friend
    {
        private long _friendId;
        public long FriendId
        {
            get { return _friendId; }
            set { _friendId = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _motherName;
        public string MotherName
        {
            get { return _motherName; }
            set { _motherName = value; }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private FriendPlaces _place;
        public FriendPlaces Place
        {
            get { return _place; }
            set { _place = value; }
        }

        private bool _hasActiveLoan;
        public bool HasActiveLoan
        {
            get { return _hasActiveLoan; }
            set { _hasActiveLoan = value; }
        }

        public Friend(string name, string motherName, string phone, FriendPlaces place)
        {
            Name = name;
            MotherName = motherName;
            Phone = phone;
            Place = place;
            HasActiveLoan = false;
        }

        public Friend()
        {

        }

        public void GetComicBook()
        {
            if (HasActiveLoan == true)
            {
                throw new MaximumLoansException();
            }
            
            HasActiveLoan = true;
        }

        public void ReturnComicBook()
        {
            HasActiveLoan = false;
        }

        public override string ToString()
        {
            return $"{FriendId} - {Name} - mãe {MotherName} - {Phone} - {Place.ToString()} - Possui empréstimo? {(HasActiveLoan ? "Sim" : "Não")}";
        }
    }
}
