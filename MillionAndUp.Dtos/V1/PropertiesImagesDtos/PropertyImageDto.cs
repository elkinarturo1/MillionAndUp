using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1.PropertiesImagesDtos
{
    public class PropertyImageDto
    {
        int IdPropertyImage { get; set; }
        int IdProperty { get; set; }
        string file { get; set; }
        string Enabled { get; set; }
    }
}
