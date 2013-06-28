using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataCalculation
{
    class RzisBaseDataCaluclation : DataCalculation<RzisBase>
    {
        public RzisBaseDataCaluclation()
        {
        }

        public RzisBaseDataCaluclation(List<RzisBase> data)
            : base(data)
        {
        }

        public override void CalculationPerform()
        {
            RzisBase prevRzis = new RzisBase();
            foreach (RzisBase curRzis in Data)
            {
                if (prevRzis != null)
                {
                    if (prevRzis.Quarter > 1)
                    {
                        prevRzis -= curRzis;
                    }
                }
                prevRzis = curRzis;
            }
        }

        public float CalculateTerminalValue(long shareNumbers)
        {
            var tvCalculationFormula = new TvCalculationFormula(
                Data.Take(4).Select(a => a.EBIT).ToList(),
                0,
                0,
                shareNumbers
                );
            return tvCalculationFormula.Calculate();
        }

    }
}
