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
        DataGridViewCellStyle ThousandFormat();
        DataGridViewCellStyle MilionFormat();
    }

    public class DisplayFormatService : IDisplayFormat
    {
        private readonly String thousandsFormat = "#,##0, k";
        private readonly String milionFormat = "#,##0,, m";

        public DataGridViewCellStyle GetBigCellStyle(String format)
        {
            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Format = format;
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            return cellStyle;
        }

        public DataGridViewCellStyle ThousandFormat()
        {
            return GetBigCellStyle(thousandsFormat);
        }

        public DataGridViewCellStyle MilionFormat()
        {
            return GetBigCellStyle(milionFormat);
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
