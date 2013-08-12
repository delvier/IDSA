using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Modules.DataCalculation
{
    class TvCalculationFormula : CalculationFormula
    {
        #region props
        public IList<long> Ebit4q { get; set; }
        public long Loans { get; set; }
        public long Cash { get; set; }
        public long NetDebt { get; set; }
        public long ShareNumbers { get; set; }
        #endregion

        #region constants
        private const float _g = 1.5f / 100; //1.5%
        private const float _wacc = 10f / 100; // 10%
        private const float _taxRate = 19f / 100; // 19%
        #endregion

        #region ctor
        public TvCalculationFormula() { }

        public TvCalculationFormula(IList<long> Ebit4q, long Loans, long Cash, long ShareNumbers)
        {
            this.Ebit4q = Ebit4q;
            this.Loans = Loans;
            this.Cash = Cash;
            //CalculateNetDebt();
            this.ShareNumbers = ShareNumbers;
        }
        #endregion
        
        #region public methods.
        private void CalculateNetDebt ()
        {
            this.NetDebt = this.Loans - this.Cash;
        }

        public override float Calculate()
        {
            CalculateNetDebt();
            var fcf = Ebit4q.Sum() * (1 - _taxRate); //cash flow to the firm.
            var tv = fcf * (1 + _g) / (_wacc - _g); // terminal value.
            var ev = tv - NetDebt; // equity value.
            result = ev / ShareNumbers; // tv per share.
            return result;
        }
        #endregion
        
    }
}
