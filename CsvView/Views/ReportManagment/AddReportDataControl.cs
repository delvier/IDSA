using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;

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

        public override void BtnOnClickAction()
        {
            throw new NotImplementedException();
        }
    }
}
