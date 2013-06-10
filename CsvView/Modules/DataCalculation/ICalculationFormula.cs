using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Modules.DataCalculation
{
    interface ICalculationFormula
    {
        float result { get; set; }
        float Calculate();
    }
}
