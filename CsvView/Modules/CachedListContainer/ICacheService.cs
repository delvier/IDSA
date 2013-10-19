using IDSA.Models;
using IDSA.Models.DataStruct;
using System;
using System.Collections.Generic;

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

        void AddCompany(Company company);

        /* Somtimes we need all data */
        IList<Company> GetAll();
         
    }
}
