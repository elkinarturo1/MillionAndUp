using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class PropertyImageDto
    {
       public int IdPropertyImage { get; set; }
       public int IdProperty { get; set; }
       public string File { get; set; }
       public string Enabled { get; set; }
    }
}
