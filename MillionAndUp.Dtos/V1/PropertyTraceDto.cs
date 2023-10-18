using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class PropertyTraceDto
    {
        int IdPropertyTrace { get; set; }
        string DateSale { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        string Tax { get; set; }
        int IdProperty { get; set; }
    }
}
