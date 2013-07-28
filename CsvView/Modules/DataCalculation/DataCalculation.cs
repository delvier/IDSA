using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IDSA.Models;

namespace IDSA.Modules.DataCalculation
{
    public abstract class DataCalculation<T> : IDataCalculation<T>
    {
        #region prop
        private IList<T> _data { get; set; }
        public IList<T> Data
        {
            get { return _data; }
        }
        #endregion

        #region Ctor
        protected DataCalculation()
        {
            this._data = new List<T>();
        }
        protected DataCalculation(IList<T> data)
        {
            this._data = data;
        }
        #endregion

        #region public methods
        public void SetData(IList<T> data)
        {
            this._data = data;
        }

        public abstract void CalculationPerform();

        public IList<T> GetData()
        {
            return _data;
        }
        #endregion

        public abstract float CalculateTerminalValue(long shareNumbers);

    }
}
