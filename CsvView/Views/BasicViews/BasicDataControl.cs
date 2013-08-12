using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters.BasicViewsPresenters;

namespace IDSA.Views.BasicViews
{
    public partial class BasicDataControl : UserControl
    {
        private readonly BasicDataControlPresenter _presenter;
        public BasicDataControl()
        {
            this._presenter =  new BasicDataControlPresenter(this);
            InitializeComponent();

            InitCompanyBox();
        }

        public void InitCompanyBox()
        {
            companyBox.DataSource = _presenter.GetCompanyCacheData();
            companyBox.DisplayMember = CsvEnums.company.Name.ToString();
        }
    }
}
