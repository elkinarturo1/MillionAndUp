using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Entities.V1
{
    public class PropertyImageEntity
    {
        int IdPropertyImage { get; set; }
        int IdProperty { get; set; }
        string file { get; set; }
        string Enabled { get; set; }
    }
}
