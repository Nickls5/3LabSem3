using System;
using System.Collections.Generic;




namespace Lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarsCatalog catalog = new CarsCatalog();
            catalog.Addcar(new Car("Mazda", "Petrol", 200));
            catalog.Addcar(new Car("Skoda", "Petrol", 180));
            catalog.Addcar(new Car("VAZ", "Diesel", 100));

            Console.WriteLine("Cars:");
            Console.WriteLine(catalog[0]);
            Console.WriteLine(catalog[1]);
            Console.WriteLine(catalog[2]);

            Car bmw1 = new Car("BMW", "Petrol", 250);
            Car bmw2 = new Car("BMW", "Petrol", 250);

            Console.WriteLine("\nIs bmw1 equal bmw2");
            Console.WriteLine(bmw1.Equals(bmw2));
        }
        
        
    }

    public class Car : IEquatable<Car>
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string name, string engine, int maxSpeed)
        {
            this.Name = name;
            this.Engine = engine;
            this.MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Car other)
        {
            if (this.Name == other.Name && this.Engine == other.Engine
                && this.MaxSpeed == other.MaxSpeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Car)obj);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Engine, MaxSpeed);
        }

    }

    public class CarsCatalog
    {
        private List<Car> cars;

        public CarsCatalog()
        {
            cars = new List<Car>();
        }

        public string this[int index]
        {
            get
            {
                var car = cars[index];
                return $"{car.Name} ({car.Engine})";
            }
        }

        public void Addcar(Car car)
        {
            cars.Add(car);
        }


    }
}
