using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using Microsoft.Practices.Prism.Events;
using IDSA.Models.DataStruct;

namespace IDSA.Events.DataControlEvents
{
    public class ReportInDataControlChangeEvent : CompositePresentationEvent<FinancialData>
    {
    }
}
