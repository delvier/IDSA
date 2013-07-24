using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IDSA.Modules.DataScanner
{
    public interface IDataScanerModule
    {
        //data
        //filterList

        //main scan function which will applay all filters on the curent data.
        void Scan();

        //select only filtered indexes.
        void SelectResultProperties();

        //filter all aplay.
        void FilterApplay(IFilter filtr);
        
        //filter Remove.
        void FilterRemove(IFilter filtr);

        //filter Add
        void FilterAdd(IFilter filtr);

        //filter ClearAll
        void FilterClearAll();

        //GetFilterAttributes
        //IList GerFilterAttribiutes();

    }
}
