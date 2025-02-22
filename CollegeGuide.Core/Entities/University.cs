using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Core.Entities
{
    public class University : BaseEntity
    {
        public int Uni_Id { get; set; }
        public string UniName { get; set; } = string.Empty;
        public string UniDescription { get; set; } = string.Empty;
        public string UniLocation { get; set; } = string.Empty;
        public string UniWebsite { get; set; } = string.Empty;
        public string UniEmail { get; set; } = string.Empty;
        public string UniPhone { get; set; } = string.Empty;
        public string UniLogo { get; set; } = string.Empty;
        public List<Recommendation> Recommendations { get; set; } = new();
        public List<College> Colleges { get; set; } = new();
        public List<FinancialAid> FinancialAids { get; set; } = new();

    }

}
