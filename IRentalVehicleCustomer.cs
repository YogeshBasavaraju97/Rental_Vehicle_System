using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRental
{
    interface IRentalVehicleCustomer
    {
        void listAvailableVehicles(Schedule wantedSchedule, VehicleType type);
        bool rentVehicle(string RegistrationNumber, Schedule wantedSchedule);
    }
}
