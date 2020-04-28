﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp14
{
    public class MyCustomException:Exception
    {
        public MyCustomException(string message) : base(message) { }
        public int ErrorCode { get; set; }
    }

    public class AnotherCustomException : Exception
    {
        public AnotherCustomException(string message,Exception innerExcepion) : base(message, innerExcepion) { }
    }
}
