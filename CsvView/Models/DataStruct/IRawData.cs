using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace IDSA.Models.DataStruct
{
    public interface IRawData
    {
        IList<String> Headers { get; set;}
        IList<IList<String>> Values { get; set; }
        void SelfClean();
    }

    public class RawData : IRawData
    {
        public RawData()
        {
            this.Headers = new List<String>();
            this.Values = new List<IList<String>>();
        }
        public IList<string> Headers
        {
            get;
            set;
        }

        public IList<IList<string>> Values
        {
            get;
            set;
        }


        public void SelfClean()
        {
            Headers = new List<String>();
            Values = new List<IList<String>>();
        }
    }
}
