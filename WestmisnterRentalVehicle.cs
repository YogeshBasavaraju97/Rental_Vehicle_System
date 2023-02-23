using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WestminsterRental
{
    class WestmisnterRentalVehicle : IRentalVehicleManager, IRentalVehicleCustomer
    {
        const int ParkingLots = 50;
        public List<Vehicle> vehicles = new List<Vehicle>(ParkingLots);
        public bool addVehicle(Vehicle V)
        {
            if(vehicles.Count==ParkingLots)
            {
                Console.WriteLine("No more Space in Parking Lot.");
            }
                return false;
            foreach(Vehicle vehicle in vehicles)
            {
                if(vehicle.registrationNumber.Equals(V.registrationNumber))
                {
                    Console.WriteLine($"Vehicle with Registration Number {V.registrationNumber} should" +
                        $"be added once");
                    return false;
                }
            }
            vehicles.Add(V);
            Console.WriteLine("Vehicle Added Successfully.");
            Console.WriteLine($"{ParkingLots - vehicles.Count} Spots Remaining in Parking Lot.");
            return true;
        }

        public bool deleteVehicle(string RegistrationNumber)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if(vehicle.registrationNumber==RegistrationNumber)
                {
                    vehicles.Remove(vehicle);
                    return true;
                }
            }
            return false;
        }

        public void generateReport(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);

            foreach (Vehicle vehicle in vehicles)
            {
                if(vehicle is Cars)
                {
                    Cars obj = (Cars)vehicle;
                    obj.saveVehicle(writer);
                }
                else if(vehicle is ElectricCars)
                {
                    ElectricCars obj = (ElectricCars)vehicle;
                    obj.saveVehicle(writer);
                }
                else if(vehicle is Motorbikes)
                {
                    Motorbikes obj = (Motorbikes)vehicle;
                    obj.saveVehicle(writer);
                }
                else
                {
                    Vans obj = (Vans)vehicle;
                    obj.saveVehicle(writer);
                }
            }

            writer.Close();
        }

        public void listVehicles()
        {
            Console.WriteLine("\nVehicle List\n\n");
            foreach(Vehicle vehicle in vehicles)
            {
                if (vehicle is Cars)
                {
                    Cars obj = (Cars)vehicle;
                    obj.outputVehicle();
                }
                else if (vehicle is ElectricCars)
                {
                    ElectricCars obj = (ElectricCars)vehicle;
                    obj.outputVehicle();
                }
                else if (vehicle is Motorbikes)
                {
                    Motorbikes obj = (Motorbikes)vehicle;
                    obj.outputVehicle();
                }
                else
                {
                    Vans obj = (Vans)vehicle;
                    obj.outputVehicle();
                }

                Console.WriteLine("\n=============================\n");
            }
        }

        public void listVehiclesOrdered()
        {
            vehicles.Sort();
            Console.WriteLine("\nVehicle List\n\n");
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Cars)
                {
                    Cars obj = (Cars)vehicle;
                    obj.outputVehicle();
                }
                else if (vehicle is ElectricCars)
                {
                    ElectricCars obj = (ElectricCars)vehicle;
                    obj.outputVehicle();
                }
                else if (vehicle is Motorbikes)
                {
                    Motorbikes obj = (Motorbikes)vehicle;
                    obj.outputVehicle();
                }
                else
                {
                    Vans obj = (Vans)vehicle;
                    obj.outputVehicle();
                }
                Console.WriteLine("\n=============================\n");
            }
        }

        public bool rentVehicle(string RegistrationNumber, Schedule wantedSchedule)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if(vehicle.registrationNumber.Equals(RegistrationNumber))
                {
                    bool overlap = false;
                    foreach (Schedule schedule in vehicle.reservations)
                    {
                        if (schedule.Overlaps(wantedSchedule))
                        {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap == false)
                    {
                        vehicle.reservations.Add(wantedSchedule);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\nVehicle Already Booked during your Wanted Schedule.");
                        return false;
                    }
                }
            }

            Console.WriteLine("Enter Valid Registration Number.");
            return false;
        }

        public void listAvailableVehicles(Schedule wantedSchedule, VehicleType type)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Cars && type == VehicleType.CAR)
                {
                    Cars obj = (Cars)vehicle;

                    bool overlap = false;
                    foreach(Schedule schedule in obj.reservations)
                    {
                        if (schedule.Overlaps(wantedSchedule))
                        {
                            overlap = true;
                            break;
                        }
                    }
                    if(overlap==false)
                        obj.outputVehicle();

                }
                else if (vehicle is ElectricCars && type == VehicleType.ELECTRIC_CAR)
                {

                    ElectricCars obj = (ElectricCars)vehicle;
                    bool overlap = false;
                    foreach (Schedule schedule in obj.reservations)
                    {
                        if (schedule.Overlaps(wantedSchedule))
                        {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap == false)
                        obj.outputVehicle();

                }
                else if (vehicle is Motorbikes && type == VehicleType.MOTORBIKE)
                {

                    Motorbikes obj = (Motorbikes)vehicle;
                    bool overlap = false;
                    foreach (Schedule schedule in obj.reservations)
                    {
                        if (schedule.Overlaps(wantedSchedule))
                        {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap == false)
                        obj.outputVehicle();

                }
                else if(vehicle is Vans && type==VehicleType.VAN)
                {

                    Vans obj = (Vans)vehicle;
                    bool overlap = false;
                    foreach (Schedule schedule in obj.reservations)
                    {
                        if (schedule.Overlaps(wantedSchedule))
                        {
                            overlap = true;
                            break;
                        }
                    }
                    if (overlap == false)
                        obj.outputVehicle();

                }
            }
        }

    }
}
