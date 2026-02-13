using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleFleetManager
{
    class Vehicle
    {
        public string Make
        {
            get
            {
                return _make;
            }
            set
            {
                _make = value;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }
        public double Mileage
        {
            get
            {
                return _mileage;
            }
            set
            {
                _mileage = value;
            }
        }
        public double LastServiceMileage
        {
            get
            {
                return _lastServiceMileage;
            }
            set
            {
                _lastServiceMileage = value;
            }
        }

        private string _make;
        private string _model;
        private int _year;
        private double _mileage;
        private double _lastServiceMileage;

        public Vehicle()
        {
            _make = "";
            _model = "";
            _year = 0;
            _mileage = 0;
            _lastServiceMileage= 0;

        }

        public Vehicle(string aMake, string aModel, int aYear, double aMileage)
        {
            Make = aMake;
            Model = aModel;
            Year = aYear;
            Mileage = aMileage;
            LastServiceMileage = aMileage;
        }

        public void AddMileage(double mileage)
        {
            if (mileage >= 0)
            {
                Mileage += mileage;
            }
            else
            {
                Console.WriteLine("Mileage added must be a positive number");
            }
        }

        public bool NeedsService()
        {
            return (Mileage - LastServiceMileage) > 10000;
        }

        public void PerformService()
        {
            _lastServiceMileage = Mileage;
        }

        public string GetSummary()
        {
            string status;
            if (NeedsService())
            {
                status = "Needs Service.";
            }
            else
            {
                status = "Does not need service.";
            }

            return $"Make: {_make}\nModel: {_model}\nYear: {_year}\nMileage: {_mileage}\nStatus: {status}";
        }
    }
}
