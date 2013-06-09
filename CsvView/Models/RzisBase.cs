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

        public static RzisBase operator -(RzisBase obj1, RzisBase obj2)
        {
            obj1.EBIT -= obj2.EBIT;
            obj1.EarningBeforeTaxes -= obj2.EarningBeforeTaxes;
            obj1.EarningOnSales -= obj2.EarningOnSales;
            obj1.NetProfit -= obj2.NetProfit;
            obj1.OwnSaleCosts -= obj2.OwnSaleCosts;
            obj1.Sales -= obj2.Sales;

            return obj1;
        }

        public static RzisBase operator +(RzisBase obj1, RzisBase obj2)
        {
            obj1.EBIT += obj2.EBIT;
            obj1.EarningBeforeTaxes += obj2.EarningBeforeTaxes;
            obj1.EarningOnSales += obj2.EarningOnSales;
            obj1.NetProfit += obj2.NetProfit;
            obj1.OwnSaleCosts += obj2.OwnSaleCosts;
            obj1.Sales += obj2.Sales;

            return obj1;
        }
    }
}
