using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRental
{
    class Schedule:IOverlappable
    {
        public DateTime pickUp;
        public DateTime dropOff;

        public Schedule(DateTime pickUp, DateTime dropOff)
        {
            this.pickUp = pickUp;
            this.dropOff = dropOff;
        }

        public bool Overlaps(Schedule other)
        {
            if(this.pickUp.CompareTo(other.dropOff)<=0)
            {
                return true;
            }

            if(other.pickUp.CompareTo(this.dropOff)<=0)
            {
                return true;
            }

            return false;
        }
    }
}
