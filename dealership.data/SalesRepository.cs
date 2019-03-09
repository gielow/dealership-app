using dealership.interfaces;
using dealership.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace dealership.data
{
    public class SalesRepository : ISalesProvider
    {
        private string FilePath { get; set; }

        public void SetFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            FilePath = filePath;
        }

        public IEnumerable<Sale> GetAll()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new Exception("File path not set");

            var sales = new List<Sale>();

            // Regex to support nested commas within column value
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            using (var reader = new StreamReader(FilePath, Encoding.GetEncoding("iso-8859-1")))
            {
                // Skip first line that only contains the columns names
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = CSVParser.Split(line);

                    var sale = new Sale();
                    sale.Id = Convert.ToInt32(values[0]);
                    sale.CustomerName = ParseUtils.RemoveOuterQuotesFromString(values[1].ToString());
                    sale.DealershipName = ParseUtils.RemoveOuterQuotesFromString(values[2]);
                    sale.Price = ParseUtils.ParseDecimalFromWithQuotes(values[4]);
                    sale.Date = ParseUtils.ParseDateTimeFromWithQuotes(values[5]);

                    var vehicle = new Vehicle();
                    // Line composition: "2017 Ferrari 488 Spider"
                    vehicle.Year = int.Parse(values[3].Substring(0, 4)); // Parse the first 4 digits as year
                    var secondSpaceIndex = values[3].IndexOf(" ", 5);
                    vehicle.Manufacturer = values[3].Substring(5, secondSpaceIndex - 5); // Extract manufacturer
                    vehicle.Model = values[3].Substring(secondSpaceIndex + 1); // Copy the rest as plain text

                    sale.Vehicle = vehicle;

                    sales.Add(sale);
                }
            }

            return sales;
        }
        
        public Sale GetById(int id)
        {
            var sales = GetAll();

            return sales.FirstOrDefault(v => v.Id == id);
        }
    }
}
