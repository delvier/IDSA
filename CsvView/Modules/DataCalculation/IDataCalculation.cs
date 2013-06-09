using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IDSA.Modules.DataCalculation
{
    public interface IDataCalculation
    {
         IList Data { get;}

         void SetData(IList data);
         void CalculationPerform();
         IList GetData();
    }
}
