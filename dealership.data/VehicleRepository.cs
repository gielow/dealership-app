using dealership.interfaces;
using dealership.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace dealership.data
{
    public class VehicleRepository : IVehiclesProvider
    {
        private string FilePath { get; set; }

        public void SetFilePath(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            FilePath = filePath;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new Exception("File path not set");

            var vehicles = new List<Vehicle>();

            // Regex to support nested commas within column value
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            using (var reader = new StreamReader(FilePath))
            {
                // Skip first line that only contains the columns names
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = CSVParser.Split(line);

                    var vehicle = new Vehicle();
                    vehicle.Id = Convert.ToInt32(values[0]);
                    vehicle.CustomerName = values[1].ToString();
                    vehicle.DealershipName = values[2];

                    // The following line is consisted of "0000 string"
                    vehicle.Year = int.Parse(values[3].Substring(0, 4)); // Parse the first 4 digits as year
                    vehicle.Model = values[3].Substring(5); // Copy the rest as plain text

                    vehicle.Price = ParseUtils.ParseDecimalFromWithQuotes(values[4]);
                    vehicle.Date = ParseUtils.ParseDateTimeFromWithQuotes(values[5]);

                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }
        
        public Vehicle GetById(int id)
        {
            var vehicles = GetAll();

            return vehicles.FirstOrDefault(v => v.Id == id);
        }
    }
}
