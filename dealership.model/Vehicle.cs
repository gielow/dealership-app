using System;

namespace dealership.model
{
    public class Vehicle : IEquatable<Vehicle>
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description => $"{Year} {Manufacturer} {Model}";

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }

        public bool Equals(Vehicle other)
        {
            if (other == null)
                return false;

            return string.Equals(this.Model, other.Model) && int.Equals(this.Year, other.Year);
        }
    }
}
