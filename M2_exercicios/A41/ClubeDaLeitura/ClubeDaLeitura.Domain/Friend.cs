using System;

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

        public Friend(string name, string motherName, string phone, FriendPlaces place)
        {
            Name = name;
            MotherName = motherName;
            Phone = phone;
            Place = place;
        }

        public Friend()
        {

        }

        public override string ToString()
        {
            return $"{FriendId} - {Name} - mãe {MotherName} - {Phone} - {Place.ToString()}";
        }
    }
}
