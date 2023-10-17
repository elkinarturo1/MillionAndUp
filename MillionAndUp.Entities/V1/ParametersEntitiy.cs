using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Entities.V1
{
    public class ParametersEntitiy
    {
        public string Name { get; set; }
        public string value { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }
}
