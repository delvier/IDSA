using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Presenters.ReportManagment
{
    interface IUserReportActionService
    {
        public ReportActionEnum userReportAction { get; set; }
    }

    class UserReportActionService : IUserReportActionService
    {
        public ReportActionEnum userReportAction
        {
            get;
            set;
        }
    }
}
