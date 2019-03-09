using dealership.model;
using System;
using System.Collections.Generic;

namespace dealership.interfaces
{
    public interface IRepository
    {
        ISalesProvider GetVehiclesProvider();
    }
}
