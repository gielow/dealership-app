using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dealership.model;

namespace dealership.data.tests.Moqs
{
    public class SalesRepositoryMoq : dealership.interfaces.ISalesProvider
    {
        public IEnumerable<Sale> GetAll()
        {
            var vehicles = new List<Vehicle>();

            var ferrari = new Vehicle()
            {
                Manufacturer = "Ferrari",
                Model = "488 Spider",
                Year = 2018
            };

            var beetle = new Vehicle()
            {
                Manufacturer = "Volkswagen",
                Model = "Beetle",
                Year = 1960
            };

            var sales = new List<Sale>();

            sales.Add(new Sale()
            {
                CustomerName = "Customer 1",
                DealershipName = "Dealership 1",
                Id = 1,
                Date = DateTime.Now,
                Price = 350000,
                Vehicle = ferrari
            });

            sales.Add(new Sale()
            {
                CustomerName = "Customer 2",
                DealershipName = "Dealership 2",
                Id = 2,
                Date = DateTime.Now,
                Price = 100000,
                Vehicle = beetle
            });

            sales.Add(new Sale()
            {
                CustomerName = "Customer 3",
                DealershipName = "Dealership 3",
                Id = 3,
                Date = DateTime.Now,
                Price = 80000,
                Vehicle = beetle
            });

            return sales;
        }

        public Sale GetById(int id)
        {
            return this.GetAll()?.FirstOrDefault(s => s.Id == id);
        }
    }
}
