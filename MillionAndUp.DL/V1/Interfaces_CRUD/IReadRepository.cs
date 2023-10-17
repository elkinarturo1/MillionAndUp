using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.DL.V1.Interfaces_CRUD
{
    public interface IReadRepository
    {
        DataSet FindById(int id);
        DataSet FindAll();
    }
}
