using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Presenters.ReportManagment
{
    interface IUserReportActionService
    {
        ReportActionEnum userReportAction { get; set; }
    }

    class UserReportActionService : IUserReportActionService
    {
        public UserReportActionService()
        {
            userReportAction = ReportActionEnum.UNDEFINED;
        }
        public ReportActionEnum userReportAction
        {
            get;
            set;
        }
    }
}
