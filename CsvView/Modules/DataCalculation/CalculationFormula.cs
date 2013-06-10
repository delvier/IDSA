using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Modules.DataCalculation
{
    public abstract class CalculationFormula : ICalculationFormula
    {
        public abstract float Calculate();
        public float result { get; set; }
    }
}
