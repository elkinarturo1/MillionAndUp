using MillionAndUp.Dtos.V1;
using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.BL.V1.Properties.Property
{
    public interface IPropertyBL
    {
        IEnumerable<PropertyEntity> accessData(Dictionary<string, object> parameters);
    }
}
