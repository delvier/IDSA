using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataCalculation
{
    class ReportDataCaluclation : DataCalculation<RzisBase>
    {

        public ReportDataCaluclation()
        {
        }

        public ReportDataCaluclation (List<RzisBase> data) : base(data) 
        {
        }

        public override void CalculationPerform()
        {
            foreach (RzisBase element in base.GetData())
	        {
                
	        }       
        }
    }
}
