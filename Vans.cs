using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WestminsterRental
{
    class Vans:Vehicle
    {
        public const VehicleType vehicleType = VehicleType.VAN;
        public Vans(string RegNumber, string make, string model)
            : base(RegNumber, make, model)
        { }

        public override void outputVehicle()
        {
            Console.WriteLine($"Registration Number: {registrationNumber}\n" +
                $"Vehicle Type: {vehicleType.ToString()}");

            if (this.reservations.Count == 0)
                Console.WriteLine("No Reservations for this Vehicle.");
            else
            {
                Console.WriteLine("===Schedule===");
                int count = 1;
                foreach (Schedule schedule in this.reservations)
                {
                    Console.WriteLine($"Reservation {count}");
                    Console.WriteLine($"Pick Up: {schedule.pickUp.Date.ToString()}");
                    Console.WriteLine($"Drop Off: {schedule.dropOff.Date.ToString()}\n");
                }
                Console.WriteLine("-------------");
            }
        }

        public override void saveVehicle(StreamWriter writer)
        {
            writer.WriteLine($"{vehicleType},{registrationNumber},{make},{model}");
        }
    }
}
