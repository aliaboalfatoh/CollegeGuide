using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Core.Entities
{
    public class College : BaseEntity
    {
        public int Col_Id { get; set; }
        public string ColName { get; set; }
        public string ColDescription { get; set; }
        public string ColWebsite { get; set; }
        public string ColLogo { get; set; }
        public float FeesEgy { get; set; }
        public float FeesInternational { get; set; }
        public float AppFeesEgy { get; set; }
        public float AppFeesInternational { get; set; }
        public float FirstInstallment { get; set; }
        public float SecInstallment { get; set; }
        public string DurationOfStudy { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Deadline { get; set; }
        public int Uni_Id { get; set; }
        public University University { get; set; }
        public List<Recommendation> Recommendations { get; set; }

    }
}



