using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1;

namespace CsvReaderModule.Controllers
{
    class CsvViewController
    {
        CsvView _view;
        CsvViewController _controller;

        public CsvViewController(CsvView view)
        {
            _view = view;
            SetController(this);

        }
        public void SetController(CsvViewController controller)
        {
            _controller = controller;
        }
    }
}
