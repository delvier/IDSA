using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Presenters.ReportManagment;

namespace IDSA.Views.ReportManagment
{
    public class AddReportDataControl : BasicDataControl
    {
        public override void SetActionBtnLabel()
        {
           actionBtn.Text = "Add Report";
        }

        public override void SetVisibleBoxOption()
        {
            EnableCompanyBox = true;
            EnableReportBox = false;
        }

        public override void BtnOnClickAction(object sender, EventArgs e)
        {
            _presenter.AddReport();
        }

        public override void SetUserActionType()
        {
            _presenter.SetUserActionType(ReportActionEnum.ADD);
        }
    }
}
