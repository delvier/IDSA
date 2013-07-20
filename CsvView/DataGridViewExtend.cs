using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA
{
    public class DataGridViewExtend : DataGridView
    {

        public DataGridViewExtend() : base()
        {
            this.AutoGenerateColumns = false;
        }

        private void generatePropertiesColumns(Type objType)
        {
            var prop = objType.GetProperties();
        }

        public void generateData (IList<Object> lst)
        {
         
        }
    }
}
