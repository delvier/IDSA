using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA.Services
{
    public interface IDisplayFormat
    {
        void ApplayGridFormatStyle(String format, DataGridViewColumnCollection cols);
        String ThousandsFormat { get; }
        String MilionFormat { get; }
    }

    public class DisplayFormatService : IDisplayFormat
    {
        private readonly String thousandsFormat = "#,##0, k";
        private readonly String milionFormat = "#,##0,, m";

        public String ThousandsFormat
        {
            get
            {
                return this.thousandsFormat;
            }
        }

        public String MilionFormat
        {
            get
            {
                return this.milionFormat;
            }
        }

        public DataGridViewCellStyle GetCellStyle(String format)
        {
            var cellStyle = new DataGridViewCellStyle();
            cellStyle.Format = format;
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            return cellStyle;
        }

        public void ApplayGridFormatStyle(String format, DataGridViewColumnCollection cols)
        {

            foreach (DataGridViewColumn col in cols)
            {
                if (col.ValueType == typeof(long))
                    col.DefaultCellStyle = GetCellStyle(format);
            }
        }


    }
}
