using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class PropertyDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public int IdOwner { get; set; }

    }
}
