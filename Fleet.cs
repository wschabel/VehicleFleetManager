using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleetManager
{
    class Fleet
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();

        public List<Vehicle> Vehicles
        {
            get
            {
                return _vehicles;
            }
            set
            {
                _vehicles = value;
            }
        }

        public void AddVehicle(Vehicle v)
        {
            _vehicles.Add(v);
        }

        public bool RemoveVehicle(string model)
        {
            Vehicle v = _vehicles.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());

            if (v != null)
            {
                _vehicles.Remove(v);
                return true;
            }
            return false;

        }

        public double GetAverageMileage()
        {
            if (_vehicles.Count > 0)
            {
                double sum = 0;
                foreach (Vehicle v in _vehicles)
                {
                    sum += v.Mileage;
                }

                double average = sum / _vehicles.Count;
                return average;
            }
            else
            {
                return 0;
            }
        }

        public void DisplayAllVehicles()
        {
            if (Vehicles.Count > 0)
            {
                foreach (Vehicle v in _vehicles)
                {
                    Console.WriteLine(v.GetSummary());
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles to display.");
            }
        }

        public void ServiceAllDue()
        {
            int serviced = 0;
            foreach (Vehicle v in _vehicles)
            {
                if (v.NeedsService())
                {
                    v.PerformService();
                    serviced++;
                }
            }
            Console.WriteLine(serviced + " vehicles serviced");
        }
    }
}
