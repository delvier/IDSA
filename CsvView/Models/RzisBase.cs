using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models
{
    public class RzisBase
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public long Sales { get; set; }
        public long OwnSaleCosts { get; set; }
        public long EarningOnSales { get; set; }
        public long EarningBeforeTaxes { get; set; }
        public long EBIT { get; set; }
        public long NetProfit { get; set; }
    }
}
