using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvReaderModule
{
    class CsvEnums
    {

        public _company Company { get; set; }
        public _financialData FinancialData { get; set; }

        public enum _company
        {
            Id,
            ColumnB,
            Name,
            Shortcut,
            ColumnE,
            ColumnF,
            Date,
            Description,
            ColumnI,
            ColumnJ,
            ColumnK,
            ColumnL,
            Href,
            PhoneNumber,
            Email,
            FullName,
            HeadAccount,
            Profile,
            Addrees,
            HrefStatus,
            ShareNumbers,
            Date2,
            ColumnW,
            ColumnX
        }
        public enum _financialData
        {
            // implement.enum.here
        }
    }
}
