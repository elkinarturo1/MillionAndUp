using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class PropertyTraceDto
    {
        public int IdPropertyTrace { get; set; }
        public string DateSale { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Tax { get; set; }
        public int IdProperty { get; set; }
    }
}
