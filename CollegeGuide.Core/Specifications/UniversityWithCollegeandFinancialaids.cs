using CollegeGuide.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Core.Specifications
{
    public class UniversityWithCollegeandFinancialaids : BaseSpecifications<University>
    {
        public UniversityWithCollegeandFinancialaids(): base(  )
        {
            Includes.Add(P => P.Colleges);
            Includes.Add(P => P.FinancialAids);
            Includes.Add(P => P.Recommendations);


        }
    }
}
