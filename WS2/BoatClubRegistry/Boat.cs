using System;

using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class Boat
    {
        private int _length;
        private BoatType _type;

        public Boat(BoatType type, int length)
        {
            _length = length;
            _type = type;
        }

        public int Length
        {
            get
            {
                return _length;
            }

            set
            {
                if(value < 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(Length), "Must be more than 0");
                }
                _length = value;
            }
        }

        public BoatType BoatType
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
    }
}