using System;
using System.Collections.Generic;
using System.Text;
using dealership.model;

namespace dealership.interfaces
{
    public interface IBaseProvider<BaseModel>
    {
        IEnumerable<BaseModel> GetAll();
        BaseModel GetById(int id);
    }
}
