using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataCalculation
{
    public interface ICalculationService
    {
        float GetTerminalValue(Company cmp);
        Company ToQuarter(Company cmp);
        Company ToPercentage(Company cmp);
    }
}
