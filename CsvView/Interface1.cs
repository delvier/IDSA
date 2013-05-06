using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;

namespace CsvReaderModule
{
    public interface ICompany
    {
        string Symbol { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Url { get; set; }
        //TRADES Trade { get; set; }
        //ObservableListSource<Report> Reports { get; set; }
    }

}
