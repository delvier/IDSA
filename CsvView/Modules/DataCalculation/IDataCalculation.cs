using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IDSA.Modules.DataCalculation
{
    public interface IDataCalculation<T>
    {
         IList<T> Data { get;}
         void SetData(IList<T> data);
         IList<T> GetData();

         void CalculationPerform();
         float CalculateTerminalValue(long shareNumbers); // rest should be used from internal data.
    }
}
