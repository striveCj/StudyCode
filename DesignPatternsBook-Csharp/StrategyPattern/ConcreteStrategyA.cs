﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsBook_Csharp.StrategyPattern
{
    class ConcreteStrategyA:Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法A实现");
        }
    }
}
