using dealership.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace dealership.interfaces
{
    public interface IVehicleReportProvider
    {
        IEnumerable<VehicleReport> GetByNumberOfSales();
    }
}
