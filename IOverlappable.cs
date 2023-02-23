
using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRental
{
    interface IOverlappable
    {
        bool Overlaps(Schedule other);
    }
}
