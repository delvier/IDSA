using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters;

namespace IDSA.Views
{
    public partial class DataFromHtmlView : UserControl
    {
        DataFromHtmlPresenter presenter;

        public DataFromHtmlView()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new DataFromHtmlPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<DataFromHtmlPresenter>();
        }
    }
}
