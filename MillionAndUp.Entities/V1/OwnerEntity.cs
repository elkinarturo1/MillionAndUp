using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Entities.V1
{
    public class OwnerEntity
    {
        int IdOwner { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Photo { get; set; }
        string Birthday { get; set; }
    }
}
