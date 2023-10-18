using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Entities.V1
{
    public class PropertyTraceEntity
    {
        public int IdPropertyTrace { get; set; }
        public string DateSale { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Tax { get; set; }
        public int IdProperty { get; set; }
    }
}
