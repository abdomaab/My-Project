﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.NetCore.JWT
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audeince { get; set; }
        public string DurationInDays { get; set; }
    }
}
