using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Dtos.V1
{
    public class OwnerDto
    {
        int IdOwner { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Photo { get; set; }
        string Birthday { get; set; }
    }
}
