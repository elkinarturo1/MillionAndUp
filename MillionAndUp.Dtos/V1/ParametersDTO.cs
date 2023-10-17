using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class ParametersDTO
    {
        public Dictionary<string, object> parameters { get; set; }
        public int page { get; set; }
        public int RowsCount { get; set; }
    }
}
