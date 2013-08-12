﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.ComponentModel;

namespace IDSA.Modules.CachedListContainer
{
    public interface ICacheService
    {
        /* Retake new data from database */
        void RefreshData();

        /* Sort company in organized order */
        void SortReports();
        
        /* Get specified company by name */
        Company GetCompany(String name);

        /* Somtimes we need all data */
        IList<Company> GetAll();

        /* Companies As Binding List */
        IBindingList GetAllInBindingList();
    }
}
