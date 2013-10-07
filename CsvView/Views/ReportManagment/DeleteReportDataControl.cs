﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;

namespace IDSA.Views.ReportManagment
{
    public class DeleteReportDataControl : BasicDataControl
    {
        public override void SetActionBtnLabel()
        {
           actionBtn.Text = "Delete Report";
        }

        public override void SetVisibleBoxOption()
        {
            EnableCompanyBox = true;
            EnableReportBox = true;
        }

        public override void BtnOnClickAction()
        {
            throw new NotImplementedException();
        }
    }
}