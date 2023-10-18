using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class ParametersDTO
    {
        public Dictionary<string, object> Parameters { get; set; }
        public int Page { get; set; }
        public int RowsCount { get; set; }
    }
}
