using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvReaderModule.Views;

namespace CsvReaderModule.Controllers
{
    class VCompanyPresenter
    {
        VCompany view;
        public VCompanyPresenter(VCompany view)
        {
            this.view = view;
        }
    }
}
