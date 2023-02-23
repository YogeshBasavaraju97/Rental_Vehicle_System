using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WestminsterRental
{
    abstract class Vehicle:IComparable
    {
        public string registrationNumber;
        public string make;
        public string model;

        public List<Schedule> reservations;

        public Vehicle(string RegNumber,string make, string model)
        {
            this.make = make;
            this.model = model;
            this.registrationNumber = RegNumber;
            reservations = new List<Schedule>();
        }
        public abstract void saveVehicle(StreamWriter writer);
        public abstract void outputVehicle();

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Vehicle other = obj as Vehicle;

            return this.make.CompareTo(other.make);
        }
    }
}
