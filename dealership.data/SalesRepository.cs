using dealership.interfaces;
using dealership.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

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

            using (var reader = new StreamReader(FilePath))
            {
                // Skip first line that only contains the columns names
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = CSVParser.Split(line);

                    var sale = new Sale();
                    sale.Id = Convert.ToInt32(values[0]);
                    sale.CustomerName = values[1].ToString();
                    sale.DealershipName = values[2];
                    sale.Price = ParseUtils.ParseDecimalFromWithQuotes(values[4]);
                    sale.Date = ParseUtils.ParseDateTimeFromWithQuotes(values[5]);

                    var vehicle = new Vehicle();
                    // The following line is consisted of "0000 string"
                    vehicle.Year = int.Parse(values[3].Substring(0, 4)); // Parse the first 4 digits as year
                    vehicle.Model = values[3].Substring(5); // Copy the rest as plain text

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
