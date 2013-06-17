using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters;
using IDSA.Models.Repository;

namespace IDSA.Views
{
    public partial class DataScanner : UserControl
    {
        private DataScannerPresenter _presenter;
        public DataScanner(IUnitOfWork uow)
        {
            InitializeComponent();
            _presenter = new DataScannerPresenter(this, uow);
        }
    }
}
