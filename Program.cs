using System;

namespace WestminsterRental
{
    class Program
    {
        public static WestmisnterRentalVehicle records = new WestmisnterRentalVehicle();
        public Schedule getUserWantedSchedule()
        {
            int pickUpDate, pickUpMonth, pickUpYear;
            int dropOffDate, dropOffMonth, dropOffYear;

            Console.WriteLine("Enter Pick-Up Date (Date/Month/Year): ");
            string date = Console.ReadLine();

            string[] dateTokens = date.Split('/');
            pickUpDate = Int32.Parse(dateTokens[0]);
            pickUpMonth = Int32.Parse(dateTokens[1]);
            pickUpYear = Int32.Parse(dateTokens[2]);

            Console.WriteLine("Enter Drop-Off Date (Date/Month/Year): ");
            date = Console.ReadLine();

            dateTokens = date.Split('/');
            dropOffDate = Int32.Parse(dateTokens[0]);
            dropOffMonth = Int32.Parse(dateTokens[1]);
            dropOffYear = Int32.Parse(dateTokens[2]);

            DateTime pickUp = new DateTime(pickUpYear, pickUpMonth, pickUpDate);
            DateTime dropOff = new DateTime(dropOffYear, dropOffMonth, dropOffDate);

            Schedule schedule = new Schedule(pickUp, dropOff);

            return schedule;
        }
        public void CustomerMenu()
        {
            int choice=3;
            do 
            {
                Console.WriteLine("\nCustomer Menu");
                Console.WriteLine("=============\n");

                Console.WriteLine("1) List the available Vehicles.");
                Console.WriteLine("2) Rent a Vehicle");
                Console.WriteLine("3) Exit the application");
                Console.WriteLine("4) Switch to Admin");
                Console.Write("Choice: ");
                choice =Int32.Parse(Console.ReadLine());

                if(choice==1)
                {
                    Schedule schedule = getUserWantedSchedule();
                    
                    Console.WriteLine("(1) Van   (2) Car   (3) Electric Car   (4) Motorbike\n");
                    VehicleType type = (VehicleType)Int32.Parse(Console.ReadLine());

                    records.listAvailableVehicles(schedule, type);
                }
                else if(choice==2)
                {
                    Schedule schedule = getUserWantedSchedule();

                    
                    Console.WriteLine("Enter Registration Number: ");
                    string regNumber = Console.ReadLine();

                    if(records.rentVehicle(regNumber,schedule)==true)
                        Console.WriteLine("Vehicle Booked.");
                }
                else if(choice==3)
                {
                    Console.WriteLine("Exiting the Applcation.");
                }
                else if(choice==4)
                {
                    AdministratorMenu();
                }
                else
                {
                    Console.WriteLine("Enter a Valid Choice.");
                }
            }
            while (choice!=3);
        }

        public void AdministratorMenu()
        {
            int choice = 7;
            do
            {
                Console.WriteLine("\nAdmin Menu\n" +
                    "==========\n"+
                "1) Add Vehicle\n" +
                "2) Delete Vehicle\n" +
                "3) List Vehicles\n" +
                "4) List Vehicles in Order\n" +
                "5) Generate Report\n" +
                "6) Switch To Customer Menu\n" +
                "7) Exit");

                choice = Int32.Parse(Console.ReadLine());

                if(choice==1)
                {
                    Console.WriteLine("(1) Van   (2) Car   (3) Electric Car   (4) Motorbike\n" +
                        "Which type of Vehicle You want to Add: ");

                    choice = Int32.Parse(Console.ReadLine());
                    string regNumber, make, model;

                    Console.Write("Enter Registration Number: ");
                    regNumber = Console.ReadLine();
                    Console.Write("Enter Make: ");
                    make = Console.ReadLine();
                    Console.Write("Enter Model: ");
                    model = Console.ReadLine();

                    if (choice == 1)
                    {
                        Vehicle van = new Vans(regNumber, make, model);

                        records.addVehicle(van);
                    }
                    else if (choice == 2)
                    {
                        Vehicle car = new Cars(regNumber, make, model);

                        records.addVehicle(car);
                    }
                    else if (choice == 3)
                    {
                        Vehicle ElectricCar = new ElectricCars(regNumber, make, model);

                        records.addVehicle(ElectricCar);
                    }
                    else if (choice == 4)
                    {
                        Vehicle bike = new Motorbikes(regNumber, make, model);

                        records.addVehicle(bike);
                    }
                    else
                    {
                        Console.WriteLine("Enter a Valid Choice.");
                    }

                }
                else if(choice==2)
                {
                    records.listVehicles();
                    string regNumber;

                    Console.Write("Enter Registration Number: ");
                    regNumber = Console.ReadLine();

                    if(records.deleteVehicle(regNumber)==false)
                    {
                        Console.Write("No Vehicle with given Registration Number.");
                    }
                    else
                    {
                        Console.WriteLine("Vehicle Deleted");
                    }
                }
                else if (choice == 3)
                {
                    records.listVehicles();
                }
                else if (choice == 4)
                {
                    records.listVehiclesOrdered();
                }
                else if (choice == 5)
                {
                    string fileName;

                    Console.WriteLine("Enter FileName: ");
                    fileName = Console.ReadLine();

                    records.generateReport(fileName);
                }
                else if (choice == 6)
                {
                    CustomerMenu();
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Exiting the Applcation.");
                }
                else
                {
                    Console.WriteLine("Enter a Valid Choice.");
                }

            } while (choice!=7);
            
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.CustomerMenu();

        }
    }
}
