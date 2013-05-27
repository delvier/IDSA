using System;
using System.Collections.Generic;
using IDSA.Models;

namespace IDSA.Services
{
    public class CompanyDataService : IDataService<Company>
    {
        public IEnumerable<Company> GetData()
        {
            var rand = new Random();
            int i = 0;
            while (true)
            {
                ++i;
                yield return new Company()
                {
                    Id = i,
                    Name = string.Format("company{0}", i),
                    FullName = string.Format("company{0}", i),
                    Profile = string.Format("typ{0}", rand.Next(1,10)),
                    Shortcut = string.Format("SRT{0}",i),
                    SharePrice = rand.Next(3,100),
                    ShareNumbers = rand.Next()
                };
            }
        }
    }
}
