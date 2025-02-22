using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Core.Entities
{
    public class FinancialAid : BaseEntity
    {
        public int Aid_Id { get; set; }
        public string Aid_Type { get; set; }
        public string AidDescription { get; set; }
        public int Uni_Id { get; set; }
        public University University { get; set; }
    }
}
