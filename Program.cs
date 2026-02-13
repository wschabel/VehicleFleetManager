using System;
using System.Runtime.CompilerServices;
using VehicleFleetManager;

Fleet fleet = new Fleet();

bool running = true;

static void DisplayMenu()
{
    Console.WriteLine("=== Vehicle Fleet Manager===");
    Console.WriteLine("1. Add Vehicle");
    Console.WriteLine("2. Remove Vehicle");
    Console.WriteLine("3. Display Fleet");
    Console.WriteLine("4. Show Average Mileage");
    Console.WriteLine("5. Service Due Vehicles");
    Console.WriteLine("6. Exit");
}

static double GetMileage()
{
    bool gettingMileage = true;
    double Mileage = 0;
    while (gettingMileage)
    {
        Console.WriteLine("What is the Mileage of the vehicle you are adding?");
        if (!Double.TryParse(Console.ReadLine(), out Mileage))
        {
            Console.WriteLine("Mileage needs to be a number");
        }
        else
        {
            gettingMileage = false;
        }
    }
    return Mileage;
}

static int GetYear()
{
    bool gettingYear = true;
    int year = 0000;
    
    while (gettingYear)
    {
        Console.WriteLine("What is the four digit Year of manufacture of the vehicle you are adding?");
        string Year = Console.ReadLine();
        if (int.TryParse(Year, out year))
        {
            if (Year.Count() == 4)
            {
                gettingYear = false;
            }
            else
            {
                Console.WriteLine("Year must be a 4 digit number.");
            }
        }
        else
        {
            Console.WriteLine("Year must be a 4 digit number.");
        }
    }
    return year;

}

static void AddVehicle(Fleet fleet)
{
    
    
    Console.WriteLine("What is the Make of the vehicle you are adding?");
    string Make = Console.ReadLine();
    Console.WriteLine("What is the Model of the vehicle you are adding?");
    string Model = Console.ReadLine();
    
    double Mileage = GetMileage();
    int Year = GetYear();

    Vehicle v = new Vehicle(Make, Model, Year, Mileage);

    fleet.AddVehicle(v);
    Console.WriteLine($"{Year} {Make} {Model} added");
}

static void RemoveVehicle(Fleet fleet)
{
    bool RemovingVehicle = true;
    while (RemovingVehicle)
    {
        if (fleet.Vehicles.Count > 0)
        {
            foreach (Vehicle v in fleet.Vehicles)
            {
                Console.WriteLine($"{fleet.Vehicles.IndexOf(v) + 1}: {v.Year} {v.Make} {v.Model}");
            }
            Console.WriteLine("What is the number of the vehicle you would like to remove?");
            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int Choice))
            {
                Choice--;
                if (Choice >= 0 && Choice < fleet.Vehicles.Count())
                {

                    string VehicleString = $"{fleet.Vehicles[Choice].Year} {fleet.Vehicles[Choice].Make} {fleet.Vehicles[Choice].Model}";

                    Console.WriteLine($"Removing {VehicleString}.");
                    Vehicle V = fleet.Vehicles[Choice];
                    bool removed = fleet.RemoveVehicle(V.Model);
                    if (removed)
                    {
                        Console.WriteLine($"{VehicleString} removed.");
                        RemovingVehicle = false;
                    }
                    else
                    {
                        Console.WriteLine("Vehicle not found.");
                    }
                }
                else
                {
                    Console.WriteLine(Choice + " is not an option.");
                }
            }
            else
            {
                Console.WriteLine(choice + " is not a number.");
            }
        }
        else
        {
            Console.WriteLine("There are no vehicles to remove.");
        }
      
    }
}


while (running)
{
    DisplayMenu();

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            AddVehicle(fleet);
            break;

        case "2":

            RemoveVehicle(fleet);
            break;

        case "3":

            fleet.DisplayAllVehicles();
            break;

        case "4":

            double average = fleet.GetAverageMileage();
            Console.WriteLine("Average mileage: " + average);
            break;

        case "5":

            fleet.ServiceAllDue();
            break;

        case "6":

            running = false;
            break;

        default:
            Console.WriteLine("That is not a valid Choice.");
            break;

    }
}    