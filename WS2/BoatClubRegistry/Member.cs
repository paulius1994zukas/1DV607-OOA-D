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
        }

        public void addBoat()
        {
            throw new System.NotImplementedException();
        }

        public void removeBoat()
        {
            throw new System.NotImplementedException();
        }

        public void editBoat()
        {
            throw new System.NotImplementedException();
        }

        public void getBoats()
        {
            throw new System.NotImplementedException();
        }

        public void getNumberOfBoats()
        {
            throw new System.NotImplementedException();
        }
    }
}