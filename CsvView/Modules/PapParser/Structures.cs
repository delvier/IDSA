using System;

namespace IDSA.Modules.PapParser
{
    public class ReportStructure
    {
        public string CompanyName { get; set; }
        public string CompanyLink { get; set; }
        public int CompanyId
        {
            get
            {
                if (string.Empty == CompanyLink)
                    return 0;
                return Convert.ToInt32(CompanyName.Split('/')[5].Split(',')[0]);
            }
        }
        public string Link { get; set; }
        public string Kind { get; set; }
    }

    public class HeaderStructure
    {
        public int factor { get; set; }
        public string currency { get; set; }
        public string period { get; set; }
        public int year { get; set; }
        public string periodOld { get; set; }
        public int yearOld { get; set; }
    }

}
