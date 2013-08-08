using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA.Services
{
    public interface IDisplayFormat
    {
        void ApplayGridFormatStyle(DataGridViewCellStyle format, DataGridViewColumnCollection cols);
        DataGridViewCellStyle GetBigCellStyle();
    }

    public class DisplayFormatService : IDisplayFormat
    {

        public DataGridViewCellStyle GetBigCellStyle()
        {
            var bigFormat = new DataGridViewCellStyle();
            bigFormat.Format = "#,##0, k";
            bigFormat.Alignment = DataGridViewContentAlignment.MiddleRight;
            return bigFormat;
        }

        public void ApplayGridFormatStyle(DataGridViewCellStyle format, DataGridViewColumnCollection cols)
        {
            foreach (DataGridViewColumn col in cols)
            {
                if (col.ValueType == typeof(long))
                    col.DefaultCellStyle = format;
            }
        }

       
    }
}
