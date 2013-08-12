using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;
using IDSA.Models;

namespace IDSA.Events.MainEvents
{
    public class CompanyChangeEvent : CompositePresentationEvent<Company>
    {
    }
}
