using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class Member
    {
        private string _name;
        private string _personIdNumber;
        private int _memberId;
        private List<BoatClubRegistry.Boat> _boats;

        public Member(string name, string personIdNumber, int memberId)
        {
            Name = name;
            PersonIdNumber = personIdNumber;
            _memberId = memberId;
            _boats = new List<Boat>();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), "Must be 1 char or longer");
                }

                _name = value;
            }
        }

        public string PersonIdNumber
        {
            get
            { return _personIdNumber; }

            set
            {
                if (value.Length != 10) //TODO: use regexp to check format. http://stackoverflow.com/questions/32624800/swedish-ssn-regular-expression-reject-users-under-a-specific-age
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), "Must be 10 digits");
                }

                _personIdNumber = value;
            }
        }

        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        public List<Boat> Boats
        {
            get { return _boats; }
            set { _boats = value; }
        }

        public void addBoat(BoatType type, int length)
        {
            _boats.Add(new Boat(type, length));
        }

        public void removeBoat(int index)
        {
            _boats.RemoveAt(index);
        }

        public void editBoat(int index, BoatType newType, int newLength)
        {
            _boats[index].BoatType = newType;
            _boats[index].Length = newLength;
        }
    }
}