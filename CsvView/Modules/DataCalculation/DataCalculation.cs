using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IDSA.Models;

namespace IDSA.Modules.DataCalculation
{
    public class DataCalculation : IDataCalculation
    {
        #region private prop
        private IList _data { get; set; }
        public IList Data
        {
            get { return _data; }
        }
        #endregion

        #region Ctor
        public DataCalculation()
        {
            this._data = new List<string>();
        }
        public DataCalculation(IList data)
        {
            this._data = data;
        }
        #endregion

        #region public methods
        public void SetData(IList data)
        {
            this._data = data;
        }

        public void CalculationPerform()
        {
            //to raw data to handle.
        }

        public IList GetData()
        {
            return _data;
        }
        #endregion




    }
}
