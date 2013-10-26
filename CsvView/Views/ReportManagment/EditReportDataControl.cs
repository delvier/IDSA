using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Presenters.ReportManagment;

namespace IDSA.Views.ReportManagment
{
    public class EditReportDataControl : BasicDataControl
    {
        public override void SetActionBtnLabel()
        {
           actionBtn.Text = "Update Report";
        }

        public override void SetVisibleBoxOption()
        {
            EnableCompanyBox = true;
            EnableReportBox = true;
        }

        public override void SetUserActionType()
        {
            _presenter.SetUserActionType(ReportActionEnum.EDIT);
        }

        public override void BtnOnClickAction(object sender, EventArgs e)
        {
            _presenter.EditReport();
        }
    }
}
