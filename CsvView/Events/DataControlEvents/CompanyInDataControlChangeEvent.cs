using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using Microsoft.Practices.Prism.Events;

namespace IDSA.Events.DataControlEvents
{
    public class CompanyInDataControlChangeEvent : CompositePresentationEvent<Company>
    {
    }
}
