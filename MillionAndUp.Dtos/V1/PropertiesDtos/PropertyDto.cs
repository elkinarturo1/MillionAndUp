using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1.PropertiesDtos
{
    public class PropertyDto
    {
        int IdProperty { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Price { get; set; }
        string CodeInternal { get; set; }
        string Year { get; set; }
        int IdOwner { get; set; }
    }
}
