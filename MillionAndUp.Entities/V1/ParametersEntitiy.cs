﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Entities.V1
{
    public class ParametersEntitiy
    {
        public Dictionary<string, object> parameters;
        public int page { get; set; }
        public int RowsCount { get; set; }       
    }
}