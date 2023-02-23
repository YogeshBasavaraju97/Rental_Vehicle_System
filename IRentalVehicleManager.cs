using System;
using System.Collections.Generic;
using System.Text;

namespace WestminsterRental
{
    interface IRentalVehicleManager
    {
        bool addVehicle(Vehicle V);
        bool deleteVehicle(string RegistrationNumber);
        void listVehicles();
        void listVehiclesOrdered();
        void generateReport(string fileName);
    }
}
